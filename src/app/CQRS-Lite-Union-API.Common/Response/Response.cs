namespace CQRS_Lite_Union_API.Common.Response
{
    public class Response : IResponse
    {
        public bool IsSuccess { get { return Error == null; } }
        protected ErrorMessage Error;
        ErrorMessage IResponse.Error => Error;

        public Response()
        {

        }

        public Response(string message, ErrorMessageType type)
        {
            Error = new ErrorMessage(message, type);
        }

        bool IResponse.IsSuccessFull()
        {
            return IsSuccess;
        }

        public static Response Ok()
        {
            return new Response();
        }

        public static Response Fail(string message, ErrorMessageType type)
        {
            return new Response(message, type);
        }

        public static Response<T> Ok<T>(T value)
        {
            return new Response<T>(value);
        }

        public static Response<T> Fail<T>(string message, ErrorMessageType type)
        {
            return new Response<T>(message, type);
        }
    }

    public class Response<T> : Response, IResponse<T>
    {
        public T Value { get; set; }

        public Response(T value) : base()
        {
            Value = value;
        }

        public Response(string message, ErrorMessageType type)
        {
            Error = new ErrorMessage(message, type);
            this.Value = default;
        }
    }
}
