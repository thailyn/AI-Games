using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Interfaces;
using TicTacToe.Game;

namespace TicTacToe.Core
{
    public abstract class TicTacToePlayer : IPlayer<TicTacToeState, TicTacToeOptions, TicTacToeMove, TicTacToePlayer>
    {
        public Symbol Symbol
        {
            get;
            protected set;
        }

        public TicTacToeState CurrentState
        {
            get;
            protected set;
        }

        public TicTacToeOptions Options
        {
            get;
            protected set;
        }

        protected TicTacToePlayer()
        {

        }
        public abstract void UpdateState(List<TicTacToeMove> moves);

        public abstract TicTacToeMove GetMove();

        protected void PrintState(TicTacToeState currentState)
        {
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
        }
    }
}
