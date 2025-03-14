using UserAPI.Application.Interfaces;
using UserAPI.Application.Services;
using UserAPI.Domain.Interfaces.Repositories;
using UserAPI.Domain.Interfaces.Services;
using UserAPI.Domain.Services;
using UserAPI.Infra.Repositories;

namespace UserAPI.Services.Configurations
{
    public class DependencyInjectionConfiguration
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserAppService, UserAppService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserDomainService, UserDomainService>();
        }
    }
}
