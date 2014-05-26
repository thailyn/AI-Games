using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Engine.Interfaces;

namespace TicTacToe.Engine
{
    public abstract class TicTacToeMove : IMove
    {
        public List<IMove> Steps
        {
            get;
            protected set;
        }

        public IPlayer PerformingPlayer
        {
            get;
            set;
        }
    }
}
