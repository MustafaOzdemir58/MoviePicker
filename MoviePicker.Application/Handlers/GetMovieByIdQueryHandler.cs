using AutoMapper;
using MediatR;
using MoviePicker.Application.Dtos;
using MoviePicker.Application.Queries;
using MoviePicker.Domain;
using MoviePicker.Infrastructure.PostgreSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker.Application.Handlers
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieDto>
    {
        private readonly IPostgreSqlRepository<Movie> _connection;
        private readonly IMapper _mapper;
        public GetMovieByIdQueryHandler(IPostgreSqlRepository<Movie> connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
        }
        public async Task<MovieDto> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var response = _connection.GetById("Select * from Movies where Id=@Id", request.Id);
            return _mapper.Map<MovieDto>(response);
        }
    }
}
