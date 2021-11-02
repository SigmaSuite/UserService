using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client.Core.DependencyInjection;
using RabbitMQ.Client.Core.DependencyInjection.Configuration;
using System;
using System.Reflection;
using UserService.Api.Mapper;
using UserService.Core.DbContexts;
using UserService.Core.DbContexts.Interfaces;
using UserService.Core.MessageBroker;
using UserService.Core.MessageBroker.Interfaces;
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
            serviceDescriptors.Configure<RabbitMqOptions>(configuration.GetSection(RabbitMqOptions.DefaultName));

            return serviceDescriptors;
        }

        public static IServiceCollection SetupCoreServices(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddTransient<IMessagePublisher, MessagePublisher>();

            var rabbitOptions = new RabbitMqOptions();
            configuration.GetSection(RabbitMqOptions.DefaultName).Bind(rabbitOptions);
            var rabbitConfig = new RabbitMqClientOptions();
            Console.WriteLine($"Hostname : {rabbitOptions.Hostname}");
            rabbitConfig.HostName = rabbitOptions.Hostname;
            Console.WriteLine($"Username: {rabbitOptions.Username}");

            rabbitConfig.UserName = rabbitOptions.Username;
            Console.WriteLine($"Password: {rabbitOptions.Password}");

            rabbitConfig.Password = rabbitOptions.Password;
            Console.WriteLine($"Port: {rabbitOptions.Port}");

            rabbitConfig.Port = rabbitOptions.Port;
            Console.WriteLine($"WirtualHost: {rabbitOptions.ExchangeOptions.VirtualHost}"); 

            rabbitConfig.VirtualHost = rabbitOptions.ExchangeOptions.VirtualHost;

            serviceDescriptors.AddRabbitMqClient(rabbitConfig);

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

        public static IServiceCollection ApplyDbMigrations(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            //serviceDescriptors.


            return serviceDescriptors;
        }
    }
}
