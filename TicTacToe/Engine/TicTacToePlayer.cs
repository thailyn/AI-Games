using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Engine.Interfaces;
using TicTacToe.Game;

namespace TicTacToe.Engine
{
    public abstract class TicTacToePlayer : IPlayer
    {
        public Symbol Symbol
        {
            get;
            protected set;
        }

        public IGameOptions Options
        {
            get;
            protected set;
        }

        protected TicTacToePlayer()
        {

        }
        public abstract void UpdateState(List<IMove> moves);

        public abstract IMove GetMove();
    }
}
