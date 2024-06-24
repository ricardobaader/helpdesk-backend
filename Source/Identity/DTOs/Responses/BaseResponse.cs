namespace Identity.DTOs.Responses
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }

        public BaseResponse()
        {
            Errors = new List<string>();
        }

        public BaseResponse(bool success = true) : this() =>
            IsSuccess = success;

        public void AddErrors(IEnumerable<string> errors) =>
           Errors.AddRange(errors);

        public void AddError(string error) => Errors.Add(error);
    }
}