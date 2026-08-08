namespace MovieManagement.API.Application.DTOs;

public record MovieDto(
    int Id,
    string Title,
    string Director,
    int ReleaseYear,
    string Genre,
    decimal Rating
);