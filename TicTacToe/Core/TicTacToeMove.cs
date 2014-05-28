using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Interfaces;

namespace TicTacToe.Core
{
    public abstract class TicTacToeMove : IMove<TicTacToeState, TicTacToeOptions, TicTacToePlayer, TicTacToeMove>
    {
        public List<TicTacToeMove> Steps
        {
            get;
            protected set;
        }

        public TicTacToePlayer PerformingPlayer
        {
            get;
            set;
        }
    }
}
