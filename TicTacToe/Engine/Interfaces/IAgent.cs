using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Engine.Interfaces
{
    public interface IAgent
    {
        IState<IGameOptions> CurrentState { get; }
        IGameOptions Options { get; }

        IMove GetMove();
        //void UpdateState<T>(IState<T> newState);
        void UpdateState(List<IMove> moves);
    }
}
