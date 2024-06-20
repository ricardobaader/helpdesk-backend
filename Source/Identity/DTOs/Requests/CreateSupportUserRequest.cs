using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.DTOs.Requests
{
    public class CreateSupportUserRequest : CreateUserRequest
    {
        public int UserType { get; set; }
    }
}
