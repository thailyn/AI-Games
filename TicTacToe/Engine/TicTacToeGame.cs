using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Engine.Interfaces;

namespace TicTacToe.Engine
{
    public class TicTacToeGame : IGame<TicTacToeOptions, TicTacToeState, TicTacToePlayer, TicTacToeMove>
    {
        public TicTacToeOptions Options
        {
            get;
            protected set;
        }

        public List<TicTacToePlayer> Players
        {
            get;
            protected set;
        }

        public TicTacToeState CurrentState
        {
            get;
            protected set;
        }

        protected TicTacToeGame()
        {
            Players = new List<TicTacToePlayer>();
        }

        public TicTacToeGame(TicTacToeOptions options)
            : this()
        {
            Options = options;
            CurrentState = new TicTacToeState(Options);
        }

        public void AddPlayer(TicTacToePlayer newPlayer)
        {
            if (Players.Count >= Options.NumPlayers)
            {
                throw new InvalidOperationException("Already at the maximum number of players.");
            }

            Players.Add(newPlayer);
        }

        public TicTacToeState GetState()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            if (Players.Count != Options.NumPlayers)
            {
                throw new InvalidOperationException("Can not start a new game until all players are entered.");
            }

            int currentPlayerIndex = 0;
            TicTacToePlayer currentPlayer = Players[currentPlayerIndex];
            TicTacToeMove lastMove = null;
            List<TicTacToeMove> newMoves = null;
            while (!CurrentState.IsEndState())
            {
                newMoves = new List<TicTacToeMove> { lastMove };
                foreach(var player in Players)
                {
                    player.UpdateState(newMoves);
                }
                
                lastMove = currentPlayer.GetMove();
                lastMove.PerformingPlayer = currentPlayer;
                CurrentState = CurrentState.ApplyMove(currentPlayer, lastMove);

                currentPlayerIndex = (currentPlayerIndex + 1) % Players.Count;
                currentPlayer = Players[currentPlayerIndex];
            }

            // notify players of end state
            newMoves = new List<TicTacToeMove> { lastMove };
            foreach (var player in Players)
            {
                player.UpdateState(newMoves);
            }
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }
    }
}
