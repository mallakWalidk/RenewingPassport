using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using RenewingPassport.Core.Common;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace RenewingPassport.Infra.Common
{
    public class DbContext: IDbContext
    {
        private DbConnection _connection;
        private readonly IConfiguration _configuration;
        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbConnection Connection 
        {
        get 
            {
                if(_connection == null)
                {
                    _connection = new OracleConnection(_configuration["ConnectionStrings:DbConnectionString"]);
                    _connection.Open();
                }
                else if(_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
             
              return _connection;
              
            }
        }
    }
}
