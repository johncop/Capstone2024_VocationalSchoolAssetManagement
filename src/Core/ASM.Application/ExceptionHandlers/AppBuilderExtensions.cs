using ASM.Application.ExceptionHandlers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASM.Application.ExceptionHandlers
{
    public static class AppBuilderExtensions
    {
        public static object GetExceptionHandler(this IServiceProvider serviceProvider, Exception exception)
        {
            var concreteType = typeof(IExceptionHandler<,>).MakeGenericType(exception.GetType(), typeof(ProblemDetails));
            var exceptionHandler = serviceProvider.GetService(concreteType);
            if (exceptionHandler == null)
            {
                exceptionHandler = serviceProvider.GetService(typeof(IExceptionHandler<Exception, ProblemDetails>));
            }
            return exceptionHandler!;
        }
    }
}
