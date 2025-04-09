
using Microsoft.AspNetCore.Http.HttpResults;
using GameLogic.Board;
using GameLogic.Board.Models;

namespace LudoBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddSingleton<IGameBoardRepo, GameBoardRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            /*var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast");*/

            app.MapGet("/api/ludo/gameboard", (string key, IGameBoardRepo repository) =>
            {
                 if (repository.TryGetBoard(key, out List<Tile> board))
                {
                    return Results.Ok(board);
                }
                else
                {
                    return Results.NotFound();
                }
            })
                .Produces<List<Tile>>(StatusCodes.Status200OK, "application/json")
                .Produces(StatusCodes.Status400BadRequest);

            app.MapGet("/diceRoll", () =>
            {
                //var diceroll
                //var calculateMoves(diceroll)

                /*var response = new
                {
                    DiceRoll = diceRoll,
                    Moves = calculateMoves
                }*/

                //return results.ok(response);
            })
                /*.Produces<Result>(StatusCodes.Status200OK, "application/json")
                .Produces(StatusCodes.Status400BadRequest)*/;
    

            app.Run();
        }
    }
}
