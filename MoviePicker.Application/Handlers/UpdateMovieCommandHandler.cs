using AutoMapper;
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

        public UpdateMovieCommandHandler(IPostgreSqlRepository<Movie> connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movieData = _mapper.Map<Movie>(request);
            var result = await _connection.Update("Update Movies set Name=@name,Point=@point,Image=@image,Description=@description where Id=@id ", new object[] { request.Name, request.Point, request.Image, request.Description, request.Id });
            return result > 0;
        }
    }
}
