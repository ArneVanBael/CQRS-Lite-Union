namespace CQRS_Lite_Union_API.Common.Response
{
    public interface IResponse
    {
    }

    public interface IResponse<T> : IResponse
    {
        public T Value { get; set; }
    }
}
