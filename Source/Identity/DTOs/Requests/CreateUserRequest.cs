namespace Identity.DTOs.Requests
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
    }
}