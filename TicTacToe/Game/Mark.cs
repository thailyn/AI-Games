using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Engine;
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

        public TicTacToePlayer Owner
        {
            get;
            protected set;
        }

        public Mark(Symbol symbol, TicTacToePlayer owner = null)
        {
            Symbol = symbol;
            Owner = owner;
        }

        public bool IsBlank()
        {
            return Symbol == Game.Symbol.Blank;
        }

        public override string ToString()
        {
            return Symbol.ToString();
        }
    }
}
