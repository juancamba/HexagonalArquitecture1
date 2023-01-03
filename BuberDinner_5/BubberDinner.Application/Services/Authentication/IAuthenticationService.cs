
using OneOf;

namespace BubberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    public OneOf<AuthenticationResult,DuplicateEmailError> Register(string firstname, string lastName, string email, string password);
    public AuthenticationResult Login(string email, string password);
   
}