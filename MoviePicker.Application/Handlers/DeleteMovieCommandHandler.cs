using AutoMapper;
using FluentValidation;
using MediatR;
using MoviePicker.Application.Commands;
using MoviePicker.Application.Validators;
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
        private readonly IValidator<DeleteMovieCommand> _validator;

        public DeleteMovieCommandHandler(IPostgreSqlRepository<Movie> connection, IValidator<DeleteMovieCommand> validator)
        {
            _connection = connection;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _connection.Delete("Update Movies set IsDeleted=true where Id=" + request.Id);
            return result > 0;
        }
    }
}
