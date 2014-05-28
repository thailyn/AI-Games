using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core;

namespace TicTacToe.Game
{
    public class HumanConsolePlayer : TicTacToePlayer
    {
        public HumanConsolePlayer(Symbol symbol, TicTacToeOptions options)
        {
            Symbol = symbol;
            Options = options;

            CurrentState = new TicTacToeState(Options);
        }

        //public void UpdateState<TicTacToeOptions>(TicTacToeState newState)
        public override void UpdateState(List<TicTacToeMove> moves)
        {
            foreach(var move in moves)
            {
                if (move == null)
                {
                    continue;
                }

                CurrentState = CurrentState.ApplyMove(move);
            }

            List<TicTacToePlayer> winningPlayers;
            if (CurrentState.IsEndState(out winningPlayers))
            {
                if (winningPlayers.Count == 0 || winningPlayers.Count > 1)
                {
                    Console.WriteLine("The game is over.  It was a draw.");
                }
                else if (winningPlayers[0] == this)
                {
                    Console.WriteLine("You won!");
                }
                else
                {
                    Console.WriteLine("You lost.");
                }

                PrintState(CurrentState);
            }
        }

        public override TicTacToeMove GetMove()
        {
            if (CurrentState == null)
            {
                Console.WriteLine("The current state is unknown.");
            }
            else
            {
                Console.WriteLine("This is the current state:");
                PrintState(CurrentState);

                System.Console.WriteLine();
            }

            System.Console.Write("Please enter the row to place a mark: ");
            int newMarkRow = System.Console.ReadLine()[0] - Convert.ToInt32('0');

            System.Console.Write("Pleae enter the column to place a mark: ");
            int newMarkColumn = System.Console.ReadLine()[0] - Convert.ToInt32('0');

            // TODO: Error checking and making sure the entered mark is both valid and unoccupied.

            return new TicTacToe.Game.PlaceMarkMove(newMarkRow, newMarkColumn);
        }
    }
}
