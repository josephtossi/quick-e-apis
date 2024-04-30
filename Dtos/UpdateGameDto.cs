using System.ComponentModel.DataAnnotations;

namespace quick_e;

public record class UpdateGameDto(
    [Required][StringLength(60)] string Name,
    [Required][StringLength(20)] string Genre,
    [Required][Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);
