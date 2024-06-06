using System.ComponentModel.DataAnnotations;

namespace Identity.DTOs.Requests
{
    public class UpdateUserRequest
    {
        [StringLength(50, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string CompanyName { get; set; }

        [StringLength(18, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres", MinimumLength = 14)]
        public string Cnpj { get; set; }
    }
}