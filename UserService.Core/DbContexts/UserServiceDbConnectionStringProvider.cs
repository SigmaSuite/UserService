using Microsoft.Extensions.Options;
using System;
using UserService.Core.DbContexts.Interfaces;
using UserService.Core.Options;

namespace UserService.Core.DbContexts
{
    public class UserServiceDbConnectionStringProvider : IUserServiceDbConnectionStringProvider
    {
        private readonly DatabaseOptions DatabaseOptions;
        public UserServiceDbConnectionStringProvider(IOptions<DatabaseOptions> databaseOptions)
        {
            DatabaseOptions = databaseOptions.Value;
        }

        public string Get()
        {
            return DatabaseOptions.ConnectionString;
        }   
    }
}
