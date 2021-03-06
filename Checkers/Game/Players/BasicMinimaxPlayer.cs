﻿using Checkers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Game.Players
{
    public class BasicMinimaxPlayer : CheckersPlayer
    {
        public BasicMinimaxPlayer(Team team, CheckersOptions options)
        {
            Team = team;
            Options = options;
        }

        public override void UpdateState(List<CheckersMove> moves)
        {
            foreach (var move in moves)
            {
                if (move == null)
                {
                    continue;
                }

                CurrentState = CurrentState.ApplyMove(move);
            }
        }

        public override CheckersMove GetMove()
        {
            var basicMinimax = new Engine.Algorithms.BasicMinimaxSearch<CheckersOptions, CheckersPlayer,
                CheckersMove, CheckersState>();
            var bestMove = basicMinimax.Search(CurrentState, CurrentState.GetAvailableMoves,
                BasicHeuristicFunction, this, 10, true);
            return bestMove;
        }

        public int BasicHeuristicFunction(CheckersState state, CheckersPlayer searchingPlayer)
        {
            int winLossvalue = 0;
            List<CheckersPlayer> winningPlayers = null;
            if (state.IsEndState(out winningPlayers))
            {
                if (winningPlayers.Count == 0 || winningPlayers.Count > 1)
                {
                    winLossvalue = 0;
                }

                var winningPlayer = winningPlayers[0];
                if (searchingPlayer.Equals(winningPlayer))
                {
                    winLossvalue = -10000;
                }
                else
                {
                    winLossvalue = 10000;
                }
            }

            int value = 0;
            int numSearchingPlayerPieces = 0;
            int numOtherPlayerPieces = 0;
            int numSearchingPlayerKings = 0;
            int numOtherPlayerKings = 0;

            foreach(var location in state.Board)
            {
                if (location.IsUnoccupied())
                {
                    continue;
                }

                if (location.Piece.Owner == searchingPlayer)
                {
                    numSearchingPlayerPieces++;
                    if (location.Piece.IsKing)
                    {
                        numSearchingPlayerKings++;
                    }
                }
                else
                {
                    numOtherPlayerPieces++;
                    if (location.Piece.IsKing)
                    {
                        numOtherPlayerKings++;
                    }
                }
            }

            value = 100 * numSearchingPlayerPieces + 500 * numSearchingPlayerKings
                - (100 * numOtherPlayerPieces + 500 * numOtherPlayerKings) + winLossvalue;

            return value;
        }
    }
}
