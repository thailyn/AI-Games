using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Engine.Interfaces;
using TicTacToe.Game;

namespace TicTacToe.Engine
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
    }
}
