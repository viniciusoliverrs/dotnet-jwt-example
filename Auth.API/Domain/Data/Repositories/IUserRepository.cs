using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.API.Domain.Entities;

namespace Auth.API.Domain.Data.Repositories
{
    public interface IUserRepository
    {
        User Exists(string username, string password);
        void Add(User entity);
        bool AvailableUserByUsername(string username);
    }
}