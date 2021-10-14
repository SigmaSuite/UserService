using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserService.Api.Mapper;
using UserService.Core.DbContexts;
using UserService.Core.DbContexts.Interfaces;
using UserService.Core.Options;
using UserService.Core.Repositories;
using UserService.Core.Repositories.Interfaces;
using UserService.Infrastructure.Commands.User;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.Api.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection RegisterHandlers(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);

            return serviceDescriptors;
        }

        public static IServiceCollection SetupAutoMapper(this IServiceCollection serviceDescriptors)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserServiceMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            serviceDescriptors.AddSingleton(mapper);

            return serviceDescriptors;
        }

        public static IServiceCollection SetupOptions(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {

            serviceDescriptors.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.DefaultName));

            return serviceDescriptors;
        }

        public static IServiceCollection SetupCoreServices(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddTransient<IUserServiceDbConnectionStringProvider, UserServiceDbConnectionStringProvider>();
            serviceDescriptors.AddTransient<IDbContextFactory<UserServiceDbContext>, UserServiceDbContextFactory>();
            serviceDescriptors.AddTransient<IUserRepository, UserRepository>();

            return serviceDescriptors;
        }

        public static IServiceCollection SetupInfrastructureServices(this IServiceCollection serviceDescriptors)
        {

            serviceDescriptors.AddTransient<IUserService, Infrastructure.Services.UserService>();
            return serviceDescriptors;
        }
    }
}
