using Application.Api.Interface.DBContext;
using Application.Api.Interface.Repository;
using Domain.Api;

namespace Infrastructure.Api.Repositories
{
    public class ValueRepository:BaseRepository<Value>, IValueRepository
    {
        public ValueRepository(IDbContext context) : base(context) { }
    }
}
