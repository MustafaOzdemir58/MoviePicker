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
                string dbName = configuration.GetSection("PostgreSql:DatabaseName").Value ?? "MoviePicker";
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
                    if (dbExists && !tablesExists)
                    {
                        string createMovieTableTxt = "CREATE TABLE IF NOT EXISTS Movies (" +
                            "Id SERIAL PRIMARY KEY, Name VARCHAR (500) NOT NULL,Image VARCHAR (500),Description VARCHAR (500), IsDeleted bool NOT NULL,CreatedDate date NOT NULL, UpdateDate date,DeletedDate date,Point double precision" +
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
