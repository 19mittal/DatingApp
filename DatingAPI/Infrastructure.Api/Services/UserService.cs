using Application.Api.Interface.Repository;
using Application.Api.Interface.Service;
using Common.Api;
using Domain.Api;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Login(string username, string password)
        {
            var users = await _userRepository.Find(u => u.UserName == username);
            var user = users.FirstOrDefault();
            if (user == null)
                return null;
            
            if (!CommonHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            return user;
            
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CommonHelper.CreatePasswordHash(password, out passwordHash,out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _userRepository.Add(user);
            await _userRepository.Complete();
            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            var users = await _userRepository.Find(m => m.UserName == username);
            return users.Any();
        }
    }
}
