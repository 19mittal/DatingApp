using Application.Api.Interface.DBContext;
using Application.Api.Interface.Repository;
using Domain.Api;

namespace Infrastructure.Api.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDbContext context) : base(context) { }
    }
}
