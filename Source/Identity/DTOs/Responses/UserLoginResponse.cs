using System.Text.Json.Serialization;

namespace Identity.DTOs.Responses
{
    public class UserLoginResponse : BaseResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Token { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? ExpirationDate { get; private set; }

        public string Name { get; set; }
        public int UserType { get; set; }
        public Guid UserId { get; set; }

        public UserLoginResponse(bool success, string token, DateTime expirationDate) : base(success)
        {
            Token = token;
            ExpirationDate = expirationDate;
        }

        public UserLoginResponse(bool success) : base(success) { }

        public void AddCustomFields(string name, int userType, Guid userId)
        {
            Name = name;
            UserType = userType;
            UserId = userId;
        }
    }
}