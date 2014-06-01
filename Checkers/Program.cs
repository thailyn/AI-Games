using Checkers.Engine;
using Checkers.Game;
using Checkers.Game.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new CheckersOptions();

            var playerOne = new RandomPlayer(Team.Red, options);
            var playerTwo = new RandomPlayer(Team.Black, options);

            var observer = new ConsoleObserver(options);

            var game = new CheckersGame(options);
            game.AddPlayer(playerOne);
            game.AddPlayer(playerTwo);
            game.AddObserver(observer);

            game.Start();

            System.Console.WriteLine("Game is finished.");
            System.Console.ReadLine();
        }
    }
}
