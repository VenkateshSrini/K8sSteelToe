using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Common.Database
{
    public class CustomDatabase : IDatabase
    {
        private readonly ILogger<CustomDatabase> _logger;
        private readonly IConfiguration _configuration;
        public CustomDatabase(ILogger<CustomDatabase> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }


        public List<string> List()
        {
            string _connectionString;
            var dbconfig = _configuration["Database:config"];
            _connectionString = _configuration[dbconfig];
           return new List<string> { _connectionString };

        }

        public bool Persist()
        {
            throw new NotImplementedException();
        }
    }
}
