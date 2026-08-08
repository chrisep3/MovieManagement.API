using Microsoft.AspNetCore.Mvc;
using MovieManagement.API.Application.DTOs;
using MovieManagement.API.Application.Services;

namespace MovieManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _service;

    public MoviesController(IMovieService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieDto>>> GetAllMovies()
    {
        var movies = await _service.GetAllMoviesAsync();
        return Ok(movies);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MovieDto>> GetMovieById(int id)
    {
        var movie = await _service.GetMovieByIdAsync(id);

        if (movie is null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    [HttpPost]
    public async Task<ActionResult<MovieDto>> CreateMovie(CreateMovieDto createDto)
    {
        var movie = await _service.CreateMovieAsync(createDto);

        return CreatedAtAction(
            nameof(GetMovieById),
            new { id = movie.Id },
            movie);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<MovieDto>> UpdateMovie(
        int id,
        UpdateMovieDto updateDto)
    {
        var movie = await _service.UpdateMovieAsync(id, updateDto);

        if (movie is null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteMovie(int id)
    {
        var deleted = await _service.DeleteMovieAsync(id);

        if (!deleted)
        {
            return NotFound($"Movie with id {id} was not found.");
        }

        return NoContent();
    }
}
