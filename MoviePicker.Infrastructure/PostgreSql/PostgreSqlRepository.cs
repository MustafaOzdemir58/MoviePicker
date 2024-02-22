using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker.Infrastructure.PostgreSql
{
    public class PostgreSqlRepository<T> : IPostgreSqlRepository<T> where T : class, new()
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        public PostgreSqlRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }
        public async Task<int> Add(string query, object param = null)
        {
            var addStatus = await _connection.ExecuteAsync(query, param);
            return addStatus;
        }

        public async Task<int> Delete(string query, object param = null)
        {
            var deleteStatus = await _connection.ExecuteAsync(query, param);
            return deleteStatus;
        }

        public async Task<IEnumerable<T>> GetAll(string query, object param = null)
        {
            var data = await _connection.QueryAsync<T>(query, param);
            return data;
        }

        public async Task<T> GetById(string query, object param = null)
        {
            var data = await _connection.QuerySingleAsync<T>(query, param);
            return data;
        }

        public async Task<int> Update(string query, object param = null)
        {
            var updateStatus = await _connection.ExecuteAsync(query, param);
            return updateStatus;
        }
    }
}
