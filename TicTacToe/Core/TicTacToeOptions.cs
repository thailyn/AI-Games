using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Interfaces;

namespace TicTacToe.Core
{
    public class TicTacToeOptions : IGameOptions<TicTacToePlayer, TicTacToeState, TicTacToeOptions, TicTacToeMove>
    {
        public int NumPlayers
        {
            get;
            protected set;
        }

        public List<TicTacToePlayer> Players
        {
            get;
            protected set;
        }

        public List<TicTacToePlayer> Observers
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
            Players = new List<TicTacToePlayer>();
            Observers = new List<TicTacToePlayer>();

            NumRows = 3;
            NumColumns = 3;
            NumToWin = 3;
        }
    }
}
