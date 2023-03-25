namespace SHUHealthApp.Server.Authentication
{
    public class AccountService
    {
        private List<Models.UserModel> userList;

        public AccountService()
        {
            userList = new List<Models.UserModel>
            {
                new Models.UserModel { UserName = "admin", Password = "1234", Role = "administrator" },
                new Models.UserModel { UserName = "user", Password = "pass", Role = "user" }
            };
        }

        public Models.UserModel? GetUserModelByUserName(string userName)
        {
            return userList.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
