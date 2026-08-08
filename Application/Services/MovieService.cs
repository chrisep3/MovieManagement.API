using MovieManagement.API.Application.DTOs;
using MovieManagement.API.Domain;
using MovieManagement.API.Infrastructure.Repositories;

namespace MovieManagement.API.Application.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repository;

    public MovieService(IMovieRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
    {
        var movies = await _repository.GetAllAsync();
        return movies.Select(MapToDto);
    }

    public async Task<MovieDto?> GetMovieByIdAsync(int id)
    {
        var movie = await _repository.GetByIdAsync(id);
        return movie is null ? null : MapToDto(movie);
    }

    public async Task<MovieDto> CreateMovieAsync(CreateMovieDto createDto)
    {
        var movie = new Movie
        {
            Title = createDto.Title,
            Director = createDto.Director,
            ReleaseYear = createDto.ReleaseYear,
            Genre = createDto.Genre,
            Rating = createDto.Rating
        };

        var createdMovie = await _repository.CreateAsync(movie);
        return MapToDto(createdMovie);
    }

    public async Task<MovieDto?> UpdateMovieAsync(
        int id,
        UpdateMovieDto updateDto)
    {
        var existingMovie = await _repository.GetByIdAsync(id);

        if (existingMovie is null)
        {
            return null;
        }

        existingMovie.Title = updateDto.Title;
        existingMovie.Director = updateDto.Director;
        existingMovie.ReleaseYear = updateDto.ReleaseYear;
        existingMovie.Genre = updateDto.Genre;
        existingMovie.Rating = updateDto.Rating;

        var updatedMovie = await _repository.UpdateAsync(existingMovie);
        return MapToDto(updatedMovie);
    }

    public async Task<bool> DeleteMovieAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    private static MovieDto MapToDto(Movie movie)
    {
        return new MovieDto(
            movie.Id,
            movie.Title,
            movie.Director,
            movie.ReleaseYear,
            movie.Genre,
            movie.Rating);
    }
}
