using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Engine.Interfaces
{
    public interface IGame<T, U, V>
        where T : IGameOptions
        where U : IState<T>
        where V : IPlayer
    {
        T Options { get; }
        List<V> Players { get; }

        void Start();
        void Pause();
        void Resume();

        U GetState();
    }
}
