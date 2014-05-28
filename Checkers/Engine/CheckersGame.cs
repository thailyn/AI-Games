using Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Engine
{
    public class CheckersGame : IGame<CheckersOptions, CheckersState, CheckersPlayer, CheckersMove>
    {
        public CheckersOptions Options
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

        protected CheckersGame()
        {

        }

        public CheckersGame(CheckersOptions options)
        {
            Options = options;
            //CurrentState = new CheckersState(Options);
        }

        public void AddPlayer(CheckersPlayer newPlayer)
        {
            if (Options.Players.Count >= Options.NumPlayers)
            {
                throw new InvalidOperationException("Already at the maximum number of players.");
            }

            Options.Players.Add(newPlayer);
        }

        public void AddObserver(CheckersPlayer newObserver)
        {
            Options.Observers.Add(newObserver);
        }

        public CheckersState GetState()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            if (Options.Players.Count != Options.NumPlayers)
            {
                throw new InvalidOperationException("Can not start a new game until all players are entered.");
            }

            throw new NotImplementedException();
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
