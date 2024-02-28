using AutoMapper;
using FluentValidation;
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
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, bool>
    {
        private readonly IPostgreSqlRepository<Movie> _connection;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateMovieCommand> _validator;

        public UpdateMovieCommandHandler(IPostgreSqlRepository<Movie> connection, IMapper mapper, IValidator<UpdateMovieCommand> validator)
        {
            _connection = connection;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<bool> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _connection.Update("Update Movies set Name=@Name,Point=@Point,Image=@Image,Description=@Description,UpdateDate=@UpdateDate where Id=@Id ", new object[] { request });
            //var result = await _connection.Update("Update Movies set Name=@name,Point=@point,Image=@image,Description=@description where Id=@id ", new object[] { request.Name, request.Point, request.Image, request.Description, request.Id });
            return result > 0;
        }
    }
}
