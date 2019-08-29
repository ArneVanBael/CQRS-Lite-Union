namespace CQRS_Lite_Union_API.Common.Response
{
    public class Response : IResponse
    {
        public bool IsSuccess { get { return Error == null; } }
        public  ErrorMessage Error { get; private set; }

        public Response()
        {

        }

        public Response(string message, ErrorMessageType type)
        {
            this.Error = new ErrorMessage(message, type);
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
    }

    public class Response<T> : Response, IResponse<T>
    {
        public T Value { get; set; }

        public Response(T value) : base()
        {
            Value = value;
        }
    }
}
