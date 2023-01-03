using BubberDinner.Application.Services.Authentication;
using BubberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace BubberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController:ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService=authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        OneOf<AuthenticationResult,DuplicateEmailError> registerResult = _authenticationService.Register(

            request.FirstName,
            request.LastName,
            request.Email,
            request.Password

        );

        // si result es AuthenticationResult       
        if(registerResult.IsT0)
        {
            var authResult = registerResult.AsT0;

                var response = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token
            );
            return Ok(response);
        }
        return Problem(statusCode:StatusCodes.Status409Conflict, title:"El email ya existe");

        //Alternativa a todo el segundo if
        // sacar el mapeo dentro del if al metod MapAuthResult
        /*
            return registerResult.Match(
                authResult=>Ok(MapAuthResult(authResult)),
                _ => Problem(statusCode:StatusCodes.Status409Conflict, title:"El email ya existe")
            );
        */     
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        
        var authResult = _authenticationService.Login(
           
            request.Email,
            request.Password

        );
        var response = new AuthenticationResponse(
        authResult.User.Id,
        authResult.User.FirstName,
        authResult.User.LastName,
        authResult.User.Email,
        authResult.Token
    );

        
        return Ok(response);
    }
}
