using Microsoft.Extensions.DependencyInjection;
using MoviePicker.Domain;
using MoviePicker.Infrastructure.PostgreSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            var assmbly = AppDomain.CurrentDomain.Load("MoviePicker.Application");
            services.AddMediatR(x =>
             {
                 x.RegisterServicesFromAssemblies(assmbly);
             });
            services.AddAutoMapper(assmbly);
            services.AddScoped<IPostgreSqlRepository<Movie>, PostgreSqlRepository<Movie>>();
        }
    }
}
