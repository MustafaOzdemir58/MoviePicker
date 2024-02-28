using FluentValidation;
using MediatR;
using MoviePicker.Application.Commands;
using MoviePicker.Application.Dtos;
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
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, bool>
    {
        private readonly IPostgreSqlRepository<Movie> _connection;
        private readonly IValidator<CreateMovieCommand> _validator;
        public CreateMovieCommandHandler(IPostgreSqlRepository<Movie> connection, IValidator<CreateMovieCommand> validator)
        {
            _connection = connection;
            _validator = validator;
        }

        public async Task<bool> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _connection.Add("Insert into Movies (Name,Point,Image,Description,IsDeleted,CreatedDate) values(@Name,@Point,@Image,@Description,false,@CreatedDate)", new object[] { request });
            return result >0;

        }
    }
}
