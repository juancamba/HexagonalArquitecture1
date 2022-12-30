using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Common.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email) ;
        void Add(User user);
    }
}