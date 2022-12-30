using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.Application.Common.Persistence;
using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public AuthenticationResult Register(string firstname, string lastName, string email, string password)
    {
        
        //1 validate que el user no existe
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("El usaurio ya existe");
        }


        // 2 create user
        var user = new User 
        {
            FirstName = firstname,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.Add(user);
        // 3 create toke

        
        //chek if user exists

        //create user (generate unique id)

        // create jwt token
        

        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(
       user,
        token
        );
    }

    public AuthenticationResult Login(string email, string password)
    {
     
        // 1 valida que existe
        if(_userRepository.GetUserByEmail(email)is not User user)
        {
            throw new Exception(" El usuario no existen");
        }
        // 2 pass ok
        if(user.Password != password)
        {
            throw new Exception(" Password NOK!");
        }

        // 3 token
        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(
        user,
        token
        );
    }
}