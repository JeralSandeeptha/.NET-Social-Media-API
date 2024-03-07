namespace SocialMediaApiLastChance.Utils
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }

        public ErrorResponse(int statusCode, string message, Object data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
    }
}
