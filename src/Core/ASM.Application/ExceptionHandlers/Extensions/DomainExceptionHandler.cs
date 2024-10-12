using ASM.Application.CustomException;
using ASM.Application.ExceptionHandlers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ASM.Application.ExceptionHandlers.Extensions
{
    public sealed class DomainExceptionHandler : IExceptionHandler<DomainException, ProblemDetails>
    {
        public ProblemDetails Handle(DomainException exception)
        {
            var errorCode = (int)HttpStatusCode.BadRequest;
            return new ProblemDetails
            {
                Status = errorCode,
                Title = Constants.RequestHandling.Messages.UnhandledExceptionTitle,
                Detail = exception.Message
            };
        }
    }
}
