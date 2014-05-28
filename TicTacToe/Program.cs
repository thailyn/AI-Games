using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core;
using TicTacToe.Game;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new TicTacToeOptions();
            //options.NumPlayers = 2;
            options.NumRows = 3;
            options.NumColumns = 3;
            options.NumToWin = 3;

            var playerOne = new BasicMinimaxPlayer(Symbol.X, options);
            var playerTwo = new BasicMinimaxPlayer(Symbol.O, options);

            var consoleObserver = new ConsoleObserver(options);

            var game = new TicTacToeGame(options);
            game.AddPlayer(playerOne);
            game.AddPlayer(playerTwo);
            game.AddObserver(consoleObserver);

            game.Start();

            System.Console.WriteLine("Game is finished.");
            System.Console.ReadLine();
        }
    }
}
