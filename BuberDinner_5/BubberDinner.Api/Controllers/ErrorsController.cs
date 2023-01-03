using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BubberDinner.Api.Controllers
{

    public class ErrorsController : ControllerBase
    {

        [Route("/error")]
        public IActionResult Error()
        {

            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

/*
            var (statusCode, message) = exception switch
            {
                DuplicateEmailException => (StatusCodes.Status409Conflict, "El mail ya existe"),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error ocurred")
            };
*/
            return Problem();
        }
    }
}