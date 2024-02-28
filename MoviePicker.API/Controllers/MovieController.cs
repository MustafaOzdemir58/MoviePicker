using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviePicker.Application.Commands;
using MoviePicker.Application.Queries;

namespace MoviePicker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create([FromBody] CreateMovieCommand model)
        {
            var response = await _mediator.Send(model);
            if (!response) return BadRequest("Movie creating failed");

            return Created();
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateMovieCommand model)
        {
            var result = await _mediator.Send(model);
            if (!result) return BadRequest("Movie editing failed");
            return Ok("Movie editing succeeded");

        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteMovieCommand model)
        {
            var result = await _mediator.Send(model);
            if (!result) return BadRequest("Movie deleting failed");
            return Ok("Movie deleting succeeded");
        }

        [HttpGet("getMovie")]
        public async Task<IActionResult> GetById([FromQuery] GetMovieByIdQuery model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetMovieListQuery());
            return Ok(result);
        }
    }
}
