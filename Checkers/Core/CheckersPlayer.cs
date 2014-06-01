using Checkers.Game;
using Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Core
{
    public abstract class CheckersPlayer : IPlayer<CheckersState, CheckersOptions, CheckersMove, CheckersPlayer>
    {
        public Team Team
        {
            get;
            protected set;
        }

        private CheckersState _currentState;
        public CheckersState CurrentState
        {
            get
            {
                if (_currentState == null && Options.Players != null && Options.Players.Count > 0)
                {
                    CurrentState = new CheckersState(Options);
                }

                return _currentState;
            }
            protected set
            {
                if (value != _currentState)
                {
                    _currentState = value;
                }
            }
        }

        public CheckersOptions Options
        {
            get;
            protected set;
        }

        protected CheckersPlayer()
        {

        }

        public abstract void UpdateState(List<CheckersMove> moves);

        public abstract CheckersMove GetMove();

        protected void PrintState(CheckersState currentState)
        {
            System.Console.Write("  ");
            for (int i = 0; i < currentState.Options.NumColumns; i++)
            {
                System.Console.Write(i);
            }
            System.Console.WriteLine();

            for (int i = 0; i < currentState.Options.NumRows; i++)
            {
                System.Console.Write(i + " ");
                for (int j = 0; j < currentState.Options.NumColumns; j++)
                {
                    int currentIndex = i * currentState.Options.NumColumns + j;
                    Location currentLocation = currentState.Board[currentIndex];

                    if (currentLocation.IsUnoccupied())
                    {
                        if ((currentIndex + i) % 2 == 0)
                        {
                            System.Console.Write(" ");
                        }
                        else
                        {
                            System.Console.Write("#");
                        }
                    }
                    else
                    {
                        Piece currentPiece = currentLocation.Piece;
                        System.Console.Write(currentPiece.ToString());
                    }
                }

                System.Console.WriteLine();
            }
        }
    }
}
