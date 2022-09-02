
using Auth.API.Domain.Data.Repositories;
using Auth.API.Domain.Entities;

namespace Auth.API.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>() {
            new User { Id = Guid.NewGuid(), Username = "robin", Password = "robin", Role = "manager" },
            new User { Id = Guid.NewGuid(), Username = "batman", Password = "batman", Role = "employee" }
        };
        public void Add(User entity) => users.Add(entity);

        public bool AvailableUserByUsername(string username) => users.Any(x => x.Username == username);
        

        public User Exists(string username, string password)
        {
            return users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password);
        }
    }
}