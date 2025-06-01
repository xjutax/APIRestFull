using Microsoft.Data.SqlClient;
using Npgsql;
using System.Data;

namespace APIRestFull.DAOs
{
    public class DapperContext_sserv
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext_sserv(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection GetConection() => new NpgsqlConnection(_connectionString);
    }
}
