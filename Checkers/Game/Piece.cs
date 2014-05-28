using Checkers.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Game
{
    public class Piece
    {
        public Team Team
        {
            get;
            protected set;
        }

        public bool IsKing
        {
            get;
            protected set;
        }

        public CheckersPlayer Owner
        {
            get;
            protected set;
        }

        public Piece(Team team, CheckersPlayer owner = null)
        {
            Team = team;
            Owner = owner;
        }

        // TODO: Return a meaningful value here!
        public override string ToString()
        {
            return "*";
        }
    }
}
