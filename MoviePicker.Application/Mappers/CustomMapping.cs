using AutoMapper;
using MoviePicker.Application.Commands;
using MoviePicker.Application.Dtos;
using MoviePicker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker.Application.Mappers
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<MovieDto, Movie>().ReverseMap();
            CreateMap<MovieListDto, Movie>().ReverseMap();
            CreateMap<UpdateMovieCommand, Movie>().ReverseMap();
        }
    }
}
