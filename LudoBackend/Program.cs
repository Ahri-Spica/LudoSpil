
using Microsoft.AspNetCore.Http.HttpResults;
using GameLogic.Board;
using GameLogic.Board.Models;
using GameLogic.Action;
using GameLogic.Engine;

namespace LudoBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();

            builder.Services.AddOpenApi();

            /*  Modules */
            builder.Services.AddSingleton<IGameBoardRepo, GameBoardRepo>();
            builder.Services.AddTransient<IDice, Dice>();
            builder.Services.AddSingleton<IGameManager, GameManager>();
            builder.Services.AddSingleton<IGameEngine, GameEngine>();

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            /*  Endpoints   */

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
                .Produces(StatusCodes.Status400BadRequest)
                .WithName("GetGameboard");

            app.MapGet("/api/ludo/diceRoll", (string player, IDice dice /*, IGL gameLogic*/) =>
            {
                int diceroll = dice.StandardDiceRoll();
                //var calculateMoves(diceroll)

                /*var response = new
                {
                    DiceRoll = diceRoll,
                    Moves = calculateMoves
                }*/

                //return Results.Ok(response);
            })
                /*.Produces<Result>(StatusCodes.Status200OK, "application/json")
                .Produces(StatusCodes.Status400BadRequest)*/;
    

            app.Run();
        }
    }
}
