using FluentValidation;
using MoviePicker.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker.Application.Validators
{
    public sealed class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Id cannot be null");
            RuleFor(command => command.Id).GreaterThan(0).WithMessage("Id must be bigger than 0");
        }
    }
}
