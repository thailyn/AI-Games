﻿using Checkers.Game;
using Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Engine
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
            for (int i = 0; i < currentState.Options.NumRows; i++)
            {
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
                        if (currentPiece.Team == Game.Team.Black)
                        {
                            if (currentPiece.IsKing)
                            {
                                System.Console.Write("B");
                            }
                            else
                            {
                                System.Console.Write("b");
                            }
                        }
                        else if (currentPiece.Team == Game.Team.Red)
                        {
                            if (currentPiece.IsKing)
                            {
                                System.Console.Write("R");
                            }
                            else
                            {
                                System.Console.Write("r");
                            }
                        }
                        else
                        {
                            if (currentPiece.IsKing)
                            {
                                System.Console.Write("N");
                            }
                            else
                            {
                                System.Console.Write("n");
                            }
                        }
                    }
                }

                System.Console.WriteLine();
            }
        }
    }
}