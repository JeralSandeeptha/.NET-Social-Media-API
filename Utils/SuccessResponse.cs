namespace SocialMediaApiLastChance.Utils
{
    public class SuccessResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }

        public SuccessResponse(int statusCode, string message, Object data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
    }
}
