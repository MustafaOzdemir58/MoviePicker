using MediatR;
using MoviePicker.Application.Commands;
using MoviePicker.Application.Dtos;
using MoviePicker.Domain;
using MoviePicker.Infrastructure.PostgreSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker.Application.Handlers
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieDto>
    {
        private readonly IPostgreSqlRepository<Movie> _connection;

        public CreateMovieCommandHandler(IPostgreSqlRepository<Movie> connection)
        {
            _connection = connection;
        }

        public async Task<CreateMovieDto> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var id = await _connection.Add("Insert into Movies (Name,Point,Image,Description,IsDeleted,CreatedDate) values(@Name,@Point,@Image,@Description,false,@CreatedDate)", new object[] { request, DateTime.Now });
            return new CreateMovieDto { Id = id };

        }
    }
}
