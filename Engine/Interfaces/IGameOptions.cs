using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Interfaces
{
    public interface IGameOptions<T, U, V, W>
        where T : IPlayer<U, V, W, T>
        where U : IState<V, T, W, U>
        where V : IGameOptions<T, U, V, W>
        where W : IMove<U, V, T, W>
    {
        int NumPlayers { get; }
        List<T> Players { get; }
        List<T> Observers { get; }
    }
}
