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
    public class GetMovieListQueryHandler : IRequestHandler<GetMovieListQuery, List<MovieListDto>>
    {
        private readonly IPostgreSqlRepository<Movie> _connection;
        private readonly IMapper _mapper;

        public GetMovieListQueryHandler(IPostgreSqlRepository<Movie> connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
        }

        public async Task<List<MovieListDto>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            var list = await _connection.GetAll("Select * from Movies where IsDeleted is false");
            return _mapper.Map<List<MovieListDto>>(list.ToList());
        }
    }
}
