using MediatR;
using MoviePicker.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker.Application.Queries
{
    public class GetMovieListQuery : IRequest<List<MovieListDto>>
    {
    }
}
