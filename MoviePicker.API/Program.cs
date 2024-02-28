using MoviePicker.Application.Extensions;
using MoviePicker.Application.Middlewares;
using MoviePicker.Infrastructure.PostgreSql;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//var assembly = AppDomain.CurrentDomain.Load("MoviePicker.Application");
//builder.Services.AddMediatR(x =>
//{
//    x.RegisterServicesFromAssemblies(assembly);
//});
IServiceCollectionExtensions.AddRepositories(builder.Services);
PostgreSqlExtensions.CreateDbIfNotExist(builder.Configuration);



var app = builder.Build();
app.UseMiddleware<ValidationExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
