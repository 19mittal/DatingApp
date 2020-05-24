using Application.Api.Interface.DBContext;
using Application.Api.Interface.Repository;
using Application.Api.Interface.Service;
using Infrastructure.Api.Repositories;
using Infrastructure.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Api;

namespace Infrastructure.Api.Dependency
{
    public static class DependencyResolver
    {
        public static void RepositoryResolver(this IServiceCollection services)
        {
            services.AddScoped<IValueRepository, ValueRepository>();
            services.AddScoped<IDbContext, DataContext>();
        }

        public static void ServiceResolver(this IServiceCollection services)
        {
            services.AddScoped<IValueService, ValueService>();
        }
    }
}
