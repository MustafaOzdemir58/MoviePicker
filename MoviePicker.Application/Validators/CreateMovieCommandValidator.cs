using AutoMapper.Configuration;
using FluentValidation;
using MoviePicker.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker.Application.Validators
{
    public sealed class CreateMovieCommandValidator :AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(command=>command.Name).NotEmpty().WithMessage("Movie Name cannot be null");
            RuleFor(command => command.Name).MinimumLength(2).WithMessage("Movie Name length must be bigger than 2");
            RuleFor(command=>command.Point).Must(y=>y>=0).WithMessage("Movie point have to be bigger than 0");
        }
    }
}
