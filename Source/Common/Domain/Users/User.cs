namespace Common.Domain.Users
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(string name, string email, string password)
        {
            SetBaseProperty();
            Name = name;
            Email = email;  
            Password = password;
        }
    }
}
