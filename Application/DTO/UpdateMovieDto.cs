using System.ComponentModel.DataAnnotations;

namespace MovieManagement.API.Application.DTOs;

public class UpdateMovieDto
{
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Director { get; set; } = string.Empty;

    [Range(1888, 2100)]
    public int ReleaseYear { get; set; }

    [Required]
    [StringLength(50)]
    public string Genre { get; set; } = string.Empty;

    [Range(typeof(decimal), "0", "10")]
    public decimal Rating { get; set; }
}