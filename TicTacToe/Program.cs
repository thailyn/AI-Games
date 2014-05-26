using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Engine;
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

            var playerOneAgent = new ConsoleHumanAgent(options);
            var playerTwoAgent = new ConsoleHumanAgent(options);

            var playerOne = new TicTacToePlayer(Symbol.X);
            playerOne.SetAgent(playerOneAgent);

            var playerTwo = new TicTacToePlayer(Symbol.O);
            playerTwo.SetAgent(playerTwoAgent);

            var game = new TicTacToeGame(options);
            game.AddPlayer(playerOne);
            game.AddPlayer(playerTwo);

            game.Start();
        }
    }
}
