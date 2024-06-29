using System.ComponentModel;

namespace Common.Domain.Users
{
    public enum UserType
    {
        [Description("Usuário")] User = 0,
        [Description("Suporte")] Employee = 1,
        [Description("Administrador")] Admin = 2
    }
}
