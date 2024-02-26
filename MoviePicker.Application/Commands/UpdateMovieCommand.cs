using MediatR;
using MoviePicker.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker.Application.Commands
{
    public class UpdateMovieCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Point { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
