using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MoviePicker.Application.Commands;
using MoviePicker.Application.Middlewares;
using MoviePicker.Application.Pipelines;
using MoviePicker.Application.Validators;
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
                 x.AddOpenBehavior(typeof(ValidationBehavior<,>));

             });
            services.AddAutoMapper(assmbly);
            #region Validators
            services.AddScoped<IValidator<CreateMovieCommand>, CreateMovieCommandValidator>();
            services.AddScoped<IValidator<DeleteMovieCommand>, DeleteMovieCommandValidator>();
            services.AddScoped<IValidator<UpdateMovieCommand>, UpdateMovieCommandValidator>();
            #endregion

            services.AddScoped<IPostgreSqlRepository<Movie>, PostgreSqlRepository<Movie>>();
        }
    }
}
