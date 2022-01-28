namespace JokeMachineApi
{
    public class UserDal
    {
        private List<UserModel> users = new List<UserModel>
        {
            new UserModel("kav","123"),
            new UserModel("camilla","1234"),
            new UserModel("mikkel","123"),

        };


        public UserModel GetUser(string username, string password)
        {
            //Find a user with same username and password
            return users.Find(x => x.Username == username && x.Password == password);
        }
    }
}
