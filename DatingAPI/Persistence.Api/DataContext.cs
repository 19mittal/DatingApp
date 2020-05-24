using Application.Api.Interface.DBContext;
using Domain.Api;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Api
{
    public class DataContext:DbContext, IDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        DbSet<Value> Values { get;set; }
    }
}
