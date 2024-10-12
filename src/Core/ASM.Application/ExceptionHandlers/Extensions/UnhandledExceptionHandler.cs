using ASM.Application.ExceptionHandlers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;
using System.Reflection;

namespace ASM.Application.ExceptionHandlers.Extensions
{
    public sealed class UnhandledExceptionHandler : IExceptionHandler<Exception, ProblemDetails>
    {
        public ProblemDetails Handle(Exception exception)
        {
            var errorCode = (int)HttpStatusCode.InternalServerError;

            if (exception is not null && exception is BadHttpRequestException)
            {
                errorCode = (int)typeof(BadHttpRequestException).GetProperty(nameof(BadHttpRequestException.StatusCode),
                                                                             bindingAttr: BindingFlags.Public | BindingFlags.Instance)!.GetValue(exception)!;
            }

            return new ProblemDetails
            {
                Status = errorCode,
                Title = Constants.RequestHandling.Messages.UnhandledExceptionTitle,
                Detail = exception!.Message
            };
        }
    }
}
