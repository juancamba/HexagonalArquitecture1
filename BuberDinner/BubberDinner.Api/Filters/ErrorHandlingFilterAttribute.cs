using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BubberDinner.Api.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            
            var exception = context.Exception;
            
            var problemDetail = new ProblemDetails{
                Title = "Ocurrio un error con la solicitud",
                Status = (int)HttpStatusCode.InternalServerError
            };
            context.Result = new ObjectResult(problemDetail);
            context.ExceptionHandled=true;
            
        }
    }
}