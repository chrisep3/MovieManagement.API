namespace MovieManagement.API.Application.DTOs;

public class MovieDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Director { get; set; } = string.Empty;

    public int ReleaseYear { get; set; }

    public string Genre { get; set; } = string.Empty;

    public decimal Rating { get; set; }
}