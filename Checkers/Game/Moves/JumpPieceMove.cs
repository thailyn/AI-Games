using Checkers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Game.Moves
{
    public class JumpPieceMove : CheckersMove
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

        public Piece JumpingPiece
        {
            get;
            protected set;
        }

        public Piece JumpedPiece
        {
            get;
            protected set;
        }

        protected JumpPieceMove()
        {
            Steps = new List<CheckersMove>();
        }

        public JumpPieceMove(int startRow, int startColumn, int endRow, int endColumn, Piece jumpingPiece,
            Piece jumpedPiece, CheckersPlayer performingPlayer = null)
            : this()
        {
            StartRow = startRow;
            StartColumn = startColumn;
            EndRow = endRow;
            EndColumn = endColumn;
            JumpingPiece = jumpingPiece;
            JumpedPiece = jumpedPiece;

            PerformingPlayer = performingPlayer;
        }
    }
}
