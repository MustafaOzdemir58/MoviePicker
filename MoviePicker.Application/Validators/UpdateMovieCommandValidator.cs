using FluentValidation;
using MoviePicker.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker.Application.Validators
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Id cannot be null");
            RuleFor(command => command.Id).GreaterThan(0).WithMessage("Id must be bigger than 0");

            RuleFor(command => command.Name).NotEmpty().WithMessage("Movie Name cannot be null");
            RuleFor(command => command.Name).MinimumLength(2).WithMessage("Movie Name length must be bigger than 2");

            RuleFor(command => command.Point).Must(y => y >= 0).WithMessage("Movie point have to be bigger than 0");
        }
    }
}
