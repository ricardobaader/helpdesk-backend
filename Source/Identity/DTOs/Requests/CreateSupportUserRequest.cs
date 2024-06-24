namespace Identity.DTOs.Requests
{
    public class CreateUserAsAdministratorRequest : CreateUserRequest
    {
        public int UserType { get; set; }
    }
}
