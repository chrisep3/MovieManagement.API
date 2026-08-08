using System.ComponentModel.DataAnnotations;

namespace MovieManagement.API.Application.DTOs;

public record CreateMovieDto(
    [property: Required]
    [property: StringLength(200)]
    string Title,

    [property: Required]
    [property: StringLength(100)]
    string Director,

    [property: Range(1888, 2100)]
    int ReleaseYear,

    [property: Required]
    [property: StringLength(50)]
    string Genre,

    [property: Range(typeof(decimal), "0", "10")]
    decimal Rating
);
