using System.ComponentModel.DataAnnotations;

namespace quick_e.Dtos;

public record class CreateGameDto(
    [Required][StringLength(60)] string Name,
    int GenreId,
    [Required][Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);
