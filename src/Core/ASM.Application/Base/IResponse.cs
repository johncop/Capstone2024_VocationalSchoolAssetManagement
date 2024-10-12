using System.Net;

namespace ASM.Application.Base
{
    public interface IResponse
    {
        HttpStatusCode StatusCode { get; }
        string Message { get; }
    }

    public interface IResponse<T> : IResponse
    {
        public T Data { get; }
    }
}
