using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Game
{
    public class Location
    {
        public Piece Piece
        {
            get;
            protected set;
        }

        public int Row
        {
            get;
            protected set;
        }

        public int Column
        {
            get;
            protected set;
        }

        public Location(int row, int column, Piece piece = null)
        {
            Row = row;
            Column = column;
            Piece = piece;
        }

        public bool IsUnoccupied()
        {
            return Piece == null;
        }

        public void PlacePiece(Piece piece)
        {
            if (!IsUnoccupied())
            {
                throw new InvalidOperationException("Can not place a piece on an occupied location.");
            }

            Piece = piece;
        }

        public Piece RemovePiece()
        {
            if (IsUnoccupied())
            {
                throw new InvalidOperationException("Can not remove a piece from an unoccupied location.");
            }

            Piece temp = Piece;
            Piece = null;

            return temp;
        }

        public override string ToString()
        {
            if (!IsUnoccupied())
            {
                return Piece.ToString();
            }

            return " ";
        }
    }
}
