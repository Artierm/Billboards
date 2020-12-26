namespace DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public string Salt { get; set; }

        public User() { }

        public User(string login, string password, string salt)
        {
            Login = login;
            Password = password;
            Salt = salt;
        }
    }
}
