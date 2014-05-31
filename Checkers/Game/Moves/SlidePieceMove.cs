using Checkers.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Game.Moves
{
    public class SlidePieceMove : CheckersMove
    {
        public int StartRow
        {
            get;
            protected set;
        }

        public int StartColumn
        {
            get;
            protected set;
        }

        public int EndRow
        {
            get;
            protected set;
        }

        public int EndColumn
        {
            get;
            protected set;
        }

        public Piece Piece
        {
            get;
            protected set;
        }

        protected SlidePieceMove()
        {
            Steps = new List<CheckersMove>();
        }

        public SlidePieceMove(int startRow, int startColumn, int endRow, int endColumn, Piece piece,
            CheckersPlayer performingPlayer = null)
            : this()
        {
            StartRow = startRow;
            StartColumn = startColumn;
            EndRow = endRow;
            EndColumn = endColumn;
            Piece = piece;

            PerformingPlayer = performingPlayer;
        }
    }
}
