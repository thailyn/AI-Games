using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Engine.Interfaces;

namespace TicTacToe.Game
{
    public enum Symbol
    {
        Blank,
        X,
        O
    }

    public class Mark
    {
        public Symbol Symbol
        {
            get;
            protected set;
        }

        public IPlayer Owner
        {
            get;
            protected set;
        }

        public Mark(Symbol symbol, IPlayer owner = null)
        {
            Symbol = symbol;
            Owner = owner;
        }

        public bool IsBlank()
        {
            return Symbol == Game.Symbol.Blank;
        }
    }
}
