using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ASM.Application.Shared
{
    [ApiController]
    public class BaseApi : ControllerBase
    {
        protected Response<T> Success<T>(string message = Constants.RequestHandling.Messages.Success,
            HttpStatusCode statusCode = HttpStatusCode.OK, T data = default)
        {
            return new Response<T>(message, statusCode, data);
        }

        protected Response Success(string message = Constants.RequestHandling.Messages.Success,
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new Response(message, statusCode);
        }

        protected Response Error(string message, HttpStatusCode httpStatusCode)
        {
            return new Response(message, httpStatusCode);
        }
    }
}
