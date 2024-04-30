using quick_e.Dtos;

namespace quick_e;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";


    // for testing purposes initialized as list
    private static readonly List<GameDto> games =
    [
    new (1, "The Witcher 3: Wild Hunt", "Action RPG", 29.99M, new DateOnly(2015, 5, 19)),
    new (2, "The Legend of Zelda: Breath of the Wild", "Action-adventure", 59.99M, new DateOnly(2017, 3, 3)),
    new (3, "Red Dead Redemption 2", "Action-adventure", 39.99M, new DateOnly(2018, 10, 26)),
    new (4, "Dark Souls III", "Action RPG", 49.99M, new DateOnly(2016, 4, 12)),
    new (5, "Grand Theft Auto V", "Action-adventure", 29.99M, new DateOnly(2013, 9, 17)),
    new (6, "The Last of Us Part II", "Action-adventure", 59.99M, new DateOnly(2020, 6, 19)),
    new (7, "Bloodborne", "Action RPG", 19.99M, new DateOnly(2015, 3, 24)),
    new (8, "Super Mario Odyssey", "Platformer", 49.99M, new DateOnly(2017, 10, 27)),
    new (9, "Horizon Zero Dawn", "Action RPG", 39.99M, new DateOnly(2017, 2, 28)),
    new(10, "Persona 5", "Role-playing", 29.99M, new DateOnly(2017, 4, 4))
    ];


    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games")
        .WithParameterValidation();

        // GET /games (fetch games)
        group.MapGet("/", () => games);

        // GET /game/1 (fetch a speciefic game from param)
        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.Id == id);
            return game == null ? Results.NotFound() : Results.Ok();
        }).WithName(GetGameEndpointName);

        // POST /games (add a game)
        group.MapPost("/", (CreateGameDto newGame) =>
        {
            // Check if the game with the same name already exists
            GameDto? selectedGame = games.Find(game => game.Name == newGame.Name);
            if (selectedGame != null) return Results.Conflict("Game with the same name already exists.");

            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );

            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        // PUT /games (edit a game)
        group.MapPut("/{id}", (int id, UpdateGameDto updateGameDto) =>
        {
            int index = games.FindIndex(game => game.Id == id);

            if (index == -1) return Results.NotFound();

            games[index] = new GameDto(
                    id,
                    updateGameDto.Name,
                    updateGameDto.Genre,
                    updateGameDto.Price,
                    updateGameDto.ReleaseDate
            );

            return Results.NoContent();
        });

        // DELETE /games (delete a game)
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);
            return Results.NoContent();
        });

        return group;
    }
}
