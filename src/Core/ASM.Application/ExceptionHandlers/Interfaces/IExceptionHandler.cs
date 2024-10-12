using Microsoft.AspNetCore.Mvc;

namespace ASM.Application.ExceptionHandlers.Interfaces
{
    public interface IExceptionHandler<in TException, out TOuput> where TException : Exception where TOuput : ProblemDetails
    {
        TOuput Handle(TException exception);
    }
}
