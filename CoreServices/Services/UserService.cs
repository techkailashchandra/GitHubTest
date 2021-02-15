using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreServices.Models;

namespace CoreServices.Services
{
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
        {
            new User { Id=1, Username = "TestUser", Password = "Password@1" }
        };

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

            return user;
        }
    }
}