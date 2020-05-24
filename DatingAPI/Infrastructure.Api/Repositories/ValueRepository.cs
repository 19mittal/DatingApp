using Application.Api.Interface.DBContext;
using Application.Api.Interface.Repository;
using Domain.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Api.Repositories
{
    public class ValueRepository:BaseRepository<Value>, IValueRepository
    {
        public ValueRepository(IDbContext context) : base(context) { }
    }
}
