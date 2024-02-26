using Microsoft.Extensions.Configuration;
using MoviePicker.Domain;
using MoviePicker.Domain.Settings;
using MoviePicker.Infrastructure.PostgreSql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MoviePicker.Application.Extensions
{
    public static class PostgreSqlExtensions
    {

        public static void CreateDbIfNotExist(IConfiguration configuration)
        {
            try
            {
                string dbName = configuration.GetSection("PostgreSql:DatabaseName").Value ??"MoviePicker";
                string connectionString = configuration.GetConnectionString("PostgreSql");
                bool dbExists = false;
                bool tablesExists = false;
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string checkDbTxt = $"Select 1 from pg_database where datname='{dbName}'";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(checkDbTxt, connection))
                    {
                        dbExists = cmd.ExecuteScalar() != null;
                    }
                    if (!dbExists)
                    {
                        string createDbTxt = $"Create DATABASE {dbName}";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(createDbTxt, connection))
                        {
                            dbExists = cmd.ExecuteScalar() != null;
                        }
                    }
                    if (dbExists && !tablesExists)
                    {
                        string createMovieTableTxt = "CREATE TABLE [IF NOT EXISTS] Movies (" +
                            "Id INTEGER PRIMARY KEY, Name VARCHAR (50) NOT NULL,Image VARCHAR (50),Description VARCHAR (500), IsDeleted bit NOT NULL,CreatedDate datetime NOT NULL, UpdateDate datetime,DeletedDate,Point DOUBLE PRECISION" +
                            ")";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(createMovieTableTxt, connection))
                        {
                            tablesExists = cmd.ExecuteScalar() != null;
                        }
                    }

                }
            }
            catch (Exception ex)
            {


            }
        }
    }
}
