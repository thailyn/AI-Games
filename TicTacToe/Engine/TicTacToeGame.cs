using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Engine.Interfaces;

namespace TicTacToe.Engine
{
    public class TicTacToeGame : IGame<TicTacToeOptions, TicTacToeState, TicTacToePlayer>
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

            IPlayer currentPlayer = Players[0];
            IMove lastMove = null;
            List<IMove> newMoves = null;
            while (!CurrentState.IsEndState())
            {
                newMoves = new List<IMove> { lastMove };
                foreach(var player in Players)
                {
                    player.UpdateState(newMoves);
                }
                
                lastMove = currentPlayer.GetMove();
                CurrentState = CurrentState.ApplyMove(lastMove) as TicTacToeState;
            }

            // notify players of end state
            newMoves = new List<IMove> { lastMove };
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
