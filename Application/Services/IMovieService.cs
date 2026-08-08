using MovieManagement.API.Application.DTOs;

namespace MovieManagement.API.Application.Services;

public interface IMovieService
{
    Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
    Task<MovieDto?> GetMovieByIdAsync(int id);
    Task<MovieDto> CreateMovieAsync(CreateMovieDto createDto);
    Task<MovieDto?> UpdateMovieAsync(int id, UpdateMovieDto updateDto);
    Task<bool> DeleteMovieAsync(int id);
}