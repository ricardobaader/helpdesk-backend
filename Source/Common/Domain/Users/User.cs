using Azure.Core;
using Common.Domain.Chats;
using Common.Domain.Tickets;
using Common.Utils;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Common.Domain.Users
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public UserType UserType { get; private set; }

        private readonly IList<Ticket> _tickets = new List<Ticket>();
        [JsonIgnore] public virtual ICollection<Ticket> Tickets => _tickets;

        private readonly IList<Ticket> _userSupportTickets = new List<Ticket>();
        [JsonIgnore] public virtual ICollection<Ticket> UserSupportTickets => _userSupportTickets;

        private readonly IList<Chat> _chats = new List<Chat>();
        [JsonIgnore] public virtual ICollection<Chat> Chats => _chats;


        protected User() { }

        public User(string name, string email, string password, string confirmPassword, UserType userType)
        {
            ValidateInfo(name, email, password, confirmPassword, userType);

            if (IsValid)
            {
                SetBaseProperties();
                Name = name;
                Email = email;
                UserType = userType;
            }
        }

        public User(string name, string email, string password, string confirmPassword)
        {
            ValidateInfo(name, email, password, confirmPassword);

            if (IsValid)
            {
                SetBaseProperties();
                Name = name;
                Email = email;
                UserType = 0;
            }
        }

        private void ValidateInfo(string name, string email, string password, string confirmPassword, UserType userType)
        {
            Regex validateEmailRegex =
                new("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");

            Errors = EntityValidator.New()
           .Requiring(name, "O nome deve ser informado")
           .Requiring(email, "O email deve ser informado")
           .When(!Enum.IsDefined(userType), "O tipo de usuário informado é inválido")
           .When(!validateEmailRegex.IsMatch(email), "O email informado é inválido")
           .Requiring(password, "A senha deve ser informada")
           .When(password != confirmPassword, "As senhas informadas devem ser iguais")
            .GetErrors();
        }

        private void ValidateInfo(string name, string email, string password, string confirmPassword)
        {
            Regex validateEmailRegex =
                new("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");

            Errors = EntityValidator.New()
           .Requiring(name, "O nome deve ser informado")
           .Requiring(email, "O email deve ser informado")
           .When(!validateEmailRegex.IsMatch(email), "O email informado é inválido")
           .Requiring(password, "A senha deve ser informada")
           .When(password != confirmPassword, "As senhas informadas devem ser iguais")
           .GetErrors();
        }
    }
}
