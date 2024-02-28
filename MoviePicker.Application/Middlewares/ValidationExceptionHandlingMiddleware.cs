using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MoviePicker.Application.ValidationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoviePicker.Application.Middlewares
{
    public sealed class ValidationExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;


        public ValidationExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException exception)
            {
                var errors = exception.Errors.Select(validationFailure => new ValidationError(
                      validationFailure.PropertyName,
                      validationFailure.ErrorMessage)).ToList();

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(errors));
            }
        }
    }
}
