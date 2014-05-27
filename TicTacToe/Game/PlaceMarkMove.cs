using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Engine;
using TicTacToe.Engine.Interfaces;

namespace TicTacToe.Game
{
    public class PlaceMarkMove : TicTacToeMove
    {
        public int NewMarkRow
        {
            get;
            protected set;
        }

        public int NewMarkColumn
        {
            get;
            protected set;
        }

        protected PlaceMarkMove()
        {
            Steps = new List<TicTacToeMove>();
        }

        public PlaceMarkMove(int newMarkRow, int newMarkColumn)
            : this()
        {
            NewMarkRow = newMarkRow;
            NewMarkColumn = newMarkColumn;
        }

        public PlaceMarkMove(int newMarkRow, int newMarkColumn, TicTacToePlayer performingPlayer)
            : this()
        {
            NewMarkRow = newMarkRow;
            NewMarkColumn = newMarkColumn;
            PerformingPlayer = performingPlayer;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}: {2}", NewMarkRow, NewMarkColumn,
                PerformingPlayer == null ? "????" : PerformingPlayer.Symbol.ToString());
        }
    }
}
