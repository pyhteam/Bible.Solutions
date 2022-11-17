namespace Bible.API.Middleware
{
    public class ApiException
    {
        public ApiException(int statusCode, string? message = null, string? detail = null)
        {
            StatusCode = statusCode;
            Message = message ?? string.Empty;
            Detail = detail ?? string.Empty;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
    }
}