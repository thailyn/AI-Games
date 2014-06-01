using Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Core
{
    public class CheckersOptions : IGameOptions<CheckersPlayer, CheckersState, CheckersOptions, CheckersMove>
    {
        public int NumPlayers
        {
            get;
            protected set;
        }

        public List<CheckersPlayer> Players
        {
            get;
            protected set;
        }

        public List<CheckersPlayer> Observers
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

        public int InitialRowsOfPieces
        {
            get;
            set;
        }

        public bool PiecesCanCaptureBackwards
        {
            get;
            set;
        }

        public bool KingsCanFly
        {
            get;
            set;
        }

        public CheckersOptions()
        {
            NumPlayers = 2;
            Players = new List<CheckersPlayer>();
            Observers = new List<CheckersPlayer>();

            NumRows = 8;
            NumColumns = 8;
            InitialRowsOfPieces = 3;

            PiecesCanCaptureBackwards = false;
            KingsCanFly = false;
        }
    }
}
