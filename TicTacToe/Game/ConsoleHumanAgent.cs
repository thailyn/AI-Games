using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Engine;
using TicTacToe.Engine.Interfaces;

namespace TicTacToe.Game
{
    public class ConsoleHumanAgent : IAgent
    {
        public IState<IGameOptions> CurrentState
        //public TicTacToeState CurrentState
        {
            get;
            protected set;
        }

        public IGameOptions Options
        {
            get;
            protected set;
        }

        public ConsoleHumanAgent(TicTacToeOptions options)
        {
            Options = options;

            // The following line sets CurrentState to null, as the return value of the
            // TicTacToeState constructor is not an IState<IGameOptions> object.
            CurrentState = new TicTacToeState(Options as TicTacToeOptions) as IState<IGameOptions>;
        }

        //public void UpdateState<TicTacToeOptions>(TicTacToeState newState)
        public void UpdateState(List<IMove> moves)
        {
            foreach(var move in moves)
            {
                if (move == null)
                {
                    continue;
                }

                CurrentState = CurrentState.ApplyMove(move) as IState<IGameOptions>;
            }
        }

        public IMove GetMove()
        {
            if (CurrentState == null)
            {
                Console.WriteLine("The current state is unknown.");
            }
            else
            {
                Console.WriteLine("This is the current state:");
                var currentState = CurrentState as TicTacToeState;
                for (int i = 0; i < currentState.Options.NumRows; i++)
                {
                    for (int j = 0; j < currentState.Options.NumColumns; j++)
                    {
                        Mark currentLocation = currentState.Board[i * currentState.Options.NumColumns + j];
                        if (currentLocation.Symbol == Symbol.Blank)
                        {
                            System.Console.Write("  ");
                        }
                        else if (currentLocation.Symbol == Symbol.X)
                        {
                            System.Console.Write("X ");
                        }
                        else
                        {
                            System.Console.Write("O ");
                        }
                    }
                    System.Console.WriteLine();
                }
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
