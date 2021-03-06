using CoreServices.Models;
using System.Threading.Tasks;
namespace CoreServices.Services
{
    public interface IUserService
    {
        Task<User>  Authenticate(string username, string password);
    }
}