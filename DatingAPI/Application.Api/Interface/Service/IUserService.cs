using Domain.Api;
using System.Threading.Tasks;

namespace Application.Api.Interface.Service
{
    public interface IUserService
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username,string password);
        Task<bool> UserExists(string username);
    }
}
