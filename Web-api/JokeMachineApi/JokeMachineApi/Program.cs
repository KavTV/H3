using JokeMachineApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    //I want the timeout to be 300 sec
    options.IdleTimeout = TimeSpan.FromSeconds(300);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Make sure session is before middleware, or middleware can not save permissions to api key user
app.UseSession();

app.UseAuthorization();

//This checks for api key for every controller
app.UseMiddleware<ApiKeyMiddleware>();


app.MapControllers();

app.Run();
