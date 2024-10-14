using ASM.Application.Base.Interfaces;
using System.Net;

namespace ASM.Application.Shared
{
    public class Response : IResponse
    {
        public Response(string message = Constants.RequestHandling.Messages.Success, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            Message = message;
            StatusCode = httpStatusCode;
        }

        public HttpStatusCode StatusCode { get; }
        public string Message { get; }
    }
    public class Response<T> : IResponse<T>
    {
        public Response(string message = Constants.RequestHandling.Messages.Success, HttpStatusCode httpStatusCode = HttpStatusCode.OK,
                        T data = default)
        {
            StatusCode = httpStatusCode;
            Message = message;
            Data = data;
        }

        public HttpStatusCode StatusCode { get; }
        public string Message { get; }
        public T Data { get; }
    }
}
