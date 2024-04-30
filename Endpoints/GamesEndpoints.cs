using quick_e.Dtos;

namespace quick_e;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        // GET /games (fetch games)
        group.MapGet("/", (GameStoreContext dbContext) => dbContext.Games);

        // GET /game/1 (fetch a speciefic game from param)
        group.MapGet("/{id}", (int id, GameStoreContext dbContext) =>
        {
            Game? game = dbContext.Games.Find(id);
            return game == null ? Results.NotFound() : Results.Ok(game);
        })
        .WithName(GetGameEndpointName);

        // POST /games (add a game)
        group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            // Check if the game with the same name already exists
            Game? selectedGame = dbContext.Games.FirstOrDefault(game => game.Name == newGame.Name);
            if (selectedGame != null) return Results.Conflict("Game with the same name already exists.");
            Game game = new()
            {
                Name = newGame.Name,
                Genre = dbContext.Genres.Find(newGame.GenreId),
                Price = newGame.Price,
                ReleaseDate = newGame.ReleaseDate
            };

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        // PUT /games (edit a game)
        group.MapPut("/{id}", (int id, UpdateGameDto updateGameDto, GameStoreContext dbContext) =>
        {
            Game? queryGame = dbContext.Games.Find(id);
            if (queryGame != null) return Results.NotFound();

            return Results.Ok(queryGame);
        });

        // DELETE /games (delete a game)
        group.MapDelete("/{id}", (int id, GameStoreContext dbContext) =>
        {
            Game? gameToBeDeleted = dbContext.Games.Find(id);
            if (gameToBeDeleted != null)
            {
                dbContext.Games.Remove(gameToBeDeleted);
                dbContext.SaveChanges();
                return Results.NoContent();
            }
            else
            {
                return Results.NotFound();
            }
        });
        return group;
    }
}