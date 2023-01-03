using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BubberDinner.Application.Common.Persistence;
using BubberDinner.Domain.Entities;

namespace BubberDinner.Infrastructure.Persistance;

public class UserRepository : IUserRepository
{
    private readonly static List<User> _users = new();
    
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u=>u.Email == email);
    }
}