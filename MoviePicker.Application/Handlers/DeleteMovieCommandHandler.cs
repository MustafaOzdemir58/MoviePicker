using AutoMapper;
using MediatR;
using MoviePicker.Application.Commands;
using MoviePicker.Domain;
using MoviePicker.Infrastructure.PostgreSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker.Application.Handlers
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, bool>
    {
        private readonly IPostgreSqlRepository<Movie> _connection;

        public DeleteMovieCommandHandler(IPostgreSqlRepository<Movie> connection)
        {
            _connection = connection;
        }

        public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var result = await _connection.Delete("Update Movies set IsDeleted=true where Id="+request.Id);
            return result > 0;
        }
    }
}
