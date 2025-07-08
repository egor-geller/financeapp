using fin.server.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UnauthorizedAccessException = fin.server.Exceptions.UnauthorizedAccessException;

namespace fin.server.Filters;

public class GlobalExceptionFilter :  IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var statusCode = context.Exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,

            ValidationException => StatusCodes.Status400BadRequest,
            
            EntityIsExists => StatusCodes.Status409Conflict,

            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,

            _ => StatusCodes.Status500InternalServerError
        };

        context.Result = new ObjectResult(new
        {
            error = context.Exception.Message,
            stackTrace = context.Exception.StackTrace
        })
        {
            StatusCode = statusCode
        };
    }
}