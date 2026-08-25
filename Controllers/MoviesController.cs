using Microsoft.AspNetCore.Mvc;
using MovieManagement.API.Application.DTOs;
using MovieManagement.API.Application.Services;

namespace MovieManagement.API.Controllers;

//[ApiController]
// Το CreateMovieDto περιέχει τους κανόνες ελέγχου. Το [ApiController] λέει στο ASP.NET Core να Ενεργοποιείσει αυτόματες ευκολίες: Automatic Model Binding από το Body, 
// αυτόματο Validation (ελέγχους) και επιστροφή 400 Bad Request αν τα δεδομένα είναι λάθος.

//[Route("api/[controller]")]
// «Ζευγαρώνει» τον Controller με την επικεφαλίδα του HTTP αιτήματος.
// Όταν έρθει ένα αίτημα με header "POST /api/movies", το .NET καταλαβαίνει 
// ότι πρέπει να το στείλει στον MoviesController για επεξεργασία.

[ApiController]  
[Route("api/[controller]")] 
public class MoviesController : ControllerBase
{
    private readonly IMovieService _service;

    public MoviesController(IMovieService service) //η μεταβλητή service έχει δηλωμένο τύπο IMovieService, αλλά το πραγματικό αντικείμενο που λαμβάνει είναι MovieService λόγω Program.cs
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
        var movie = await _service.GetMovieByIdAsync(id);// το MovieDTO δημιουργείται μέσα στο service, αν υπάρχει

        if (movie is null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    [HttpPost]
    public async Task<ActionResult<MovieDto>> CreateMovie(CreateMovieDto createDto)
    {
        var movie = await _service.CreateMovieAsync(createDto); // 1. Καλούμε το Service για να κάνει τη δουλειά ΟΛΗ ΩΣ ΤΗ ΒΑΣΗ ΚΑΙ ΠΙΣΩ

        // 1.επιλέγει το σχέδιο URL πχ /api/Movies/{id} 2.συμπληρώνει το Id 3.το movie που θα γίνει JSON Body 4.παράγει 201 Created
        return CreatedAtAction(
            nameof(GetMovieById),
            new { id = movie.Id },
            movie); // 2. Επιστρέφουμε HTTP 201 Created μαζί με το αποτέλεσμα
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<MovieDto>> UpdateMovie(int id, UpdateMovieDto updateDto)
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
        var serviceResult = await _service.DeleteMovieAsync(id);

        if (!serviceResult)
        {
            return NotFound($"Movie with id {id} was not found.");
        }

        return NoContent();
    }
}
