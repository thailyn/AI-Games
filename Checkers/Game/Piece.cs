using Checkers.Core;
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

        public override string ToString()
        {
            if (Team == Game.Team.Black)
            {
                if (IsKing)
                {
                    return "B";
                }
                else
                {
                    return "b";
                }
            }
            else if (Team == Game.Team.Red)
            {
                if (IsKing)
                {
                    return "R";
                }
                else
                {
                    return "r";
                }
            }
            else
            {
                if (IsKing)
                {
                    return "N";
                }
                else
                {
                    return "n";
                }
            }
        }
    }
}
