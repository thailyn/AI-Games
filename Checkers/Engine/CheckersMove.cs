using Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Engine
{
    public class CheckersMove : IMove<CheckersState, CheckersOptions, CheckersPlayer, CheckersMove>
    {
        public List<CheckersMove> Steps
        {
            get;
            protected set;
        }

        public CheckersPlayer PerformingPlayer
        {
            get;
            set;
        }
    }
}
