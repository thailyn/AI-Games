using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Engine.Interfaces
{
    public interface IPlayer<T, U, V, W>
        where T : IState<U, W, V, T>
        where U : IGameOptions
        where V : IMove<T, U, W, V>
        where W : IPlayer<T, U, V, W>
    {
        U Options { get; }
        T CurrentState { get; }

        void UpdateState(List<V> moves);
        V GetMove();
    }
}
