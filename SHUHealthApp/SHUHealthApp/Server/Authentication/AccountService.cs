namespace SHUHealthApp.Server.Authentication
{
    public class AccountService
    {
        private List<UserModel> _userAccountList;

        public AccountService()
        {
            _userAccountList = new List<UserModel>
            {
                new UserModel{ UserName = "admin", Password = "admin", Role = "Administrator" },
                new UserModel{ UserName = "user", Password = "user", Role = "User" }
            };
        }

        public UserModel? GetUserModelByUserName(string userName)
        {
            return _userAccountList.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
