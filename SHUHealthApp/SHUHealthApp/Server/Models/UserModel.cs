namespace SHUHealthApp.Server.Models
{
    public class UserModel
    {
        public string UserName { get; set; } //the username of the person logging in
        public string Password { get; set; } //password of username logging in
        public string Name { get; set; }    //Name of user logging in
        public string Email { get; set; }   //email of user logging in
        public string Role { get; set; }    //user role. Current roles are: Admin (can add and remove users), user (can access the system)
    }
}
