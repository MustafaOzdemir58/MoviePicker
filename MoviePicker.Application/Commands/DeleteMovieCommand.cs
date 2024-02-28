using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker.Application.Commands
{
    public sealed class DeleteMovieCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
