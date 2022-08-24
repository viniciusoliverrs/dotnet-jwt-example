using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.API.Models;

namespace Auth.API.Data.Repositories
{
    public static class UserRepossitory
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = Guid.NewGuid(), Username = "manager", Password = "manager", Role = "manager" });
            users.Add(new User { Id = Guid.NewGuid(), Username = "employee", Password = "employee", Role = "employee" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}