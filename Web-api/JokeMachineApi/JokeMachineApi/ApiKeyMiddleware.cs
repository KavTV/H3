namespace JokeMachineApi
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEYNAME = "ApiKey";
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            //Look for the api key with name ApiKey in header and find its value
            //If no api keey found, tell the user no key were found
            if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided");
                return;
            }
            //Get the api keys
            SavedApiKeys apiKeys = new SavedApiKeys();

            //Try to find the api key in the dictionary, if not, then the key does not exist
            //Usually you would search for it in the database
            //ApiKey apiKey = null;
            apiKeys.apiKeys.TryGetValue(extractedApiKey, out ApiKey apiKey);


            //If the retrieved api key is null, then it does not exist
            if (apiKey == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client");
                return;
            }
            //Save the categories that the api key allows
            context.Session.SetObjectAsJson("AllowedCategories", apiKey.AllowedCategories);

            await _next(context);
        }
    }
}
