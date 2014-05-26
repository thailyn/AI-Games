using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Engine.Interfaces;
using TicTacToe.Game;

namespace TicTacToe.Engine
{
    public class TicTacToePlayer : IPlayer
    {
        public IAgent Agent
        {
            get;
            protected set;
        }

        public Symbol Symbol
        {
            get;
            protected set;
        }

        public TicTacToePlayer(Symbol symbol)
        {
            Symbol = symbol;
        }

        public void UpdateState(List<IMove> moves)
        {
            Agent.UpdateState(moves);
        }

        public IMove GetMove()
        {
            
            IMove move = Agent.GetMove();
            move.PerformingPlayer = this;
            return move;
        }

        public void SetAgent(IAgent newAgent)
        {
            Agent = newAgent;
        }
    }
}
