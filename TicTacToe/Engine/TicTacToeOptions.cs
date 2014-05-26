using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Engine.Interfaces;

namespace TicTacToe.Engine
{
    public class TicTacToeOptions : IGameOptions
    {
        public int NumPlayers
        {
            get;
            protected set;
        }

        public int NumRows
        {
            get;
            set;
        }

        public int NumColumns
        {
            get;
            set;
        }

        public int NumToWin
        {
            get;
            set;
        }

        public TicTacToeOptions()
        {
            NumPlayers = 2;

            NumRows = 3;
            NumColumns = 3;
            NumToWin = 3;
        }
    }
}
