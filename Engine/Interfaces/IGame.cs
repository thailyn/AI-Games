using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Interfaces
{
    public interface IGame<T, U, V, W>
        where T : IGameOptions<V, U, T, W>
        where U : IState<T, V, W, U>
        where V : IPlayer<U, T, W, V>
        where W : IMove<U, T, V, W>
    {
        T Options { get; }
        //List<V> Players { get; }

        void Start();
        void Pause();
        void Resume();

        U GetState();
    }
}
