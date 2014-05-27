using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Interfaces
{
    public interface IMove<T, U, V, W>
        where T : IState<U, V, W, T>
        where U : IGameOptions<V, T, U, W>
        where V : IPlayer<T, U, W, V>
        where W : IMove<T, U, V, W>
    {
        List<W> Steps { get; }
        V PerformingPlayer { get; set; }
    }
}
