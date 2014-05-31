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

        public bool IsJumped
        {
            get;
            protected set;
        }

        public CheckersPlayer Owner
        {
            get;
            protected set;
        }

        public Piece(Team team, CheckersPlayer owner = null, bool isKing = false,
            bool isJumped = false)
        {
            Team = team;
            Owner = owner;

            IsKing = isKing;
            IsJumped = isJumped;
        }

        public void MakeKing()
        {
            if (IsKing)
            {
                throw new InvalidOperationException();
            }

            IsKing = true;
        }

        public void MakeJumped()
        {
            if (IsJumped)
            {
                throw new InvalidOperationException();
            }

            IsJumped = true;
        }

        // TODO: Return a meaningful value here!
        public override string ToString()
        {
            return "*";
        }
    }
}
