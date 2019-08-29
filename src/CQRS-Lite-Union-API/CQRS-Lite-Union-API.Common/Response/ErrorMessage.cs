namespace CQRS_Lite_Union_API.Common.Response
{
    public class ErrorMessage
    {
        public ErrorMessage(string message, ErrorMessageType type)
        {
            Message = message;
            Type = type;
        }

        public string Message { get; set; }
        public ErrorMessageType Type { get; set; }
    }

    public enum ErrorMessageType
    {
        NotFound = 404,
        InternalServerError = 500,
        Conflict = 409,
        BadRequest = 400,
    }
}
