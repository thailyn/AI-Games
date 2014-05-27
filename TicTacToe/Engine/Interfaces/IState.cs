using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Engine.Interfaces
{
    public interface IState<T, U, V, W>
        where T : IGameOptions
        where U : IPlayer<W, T, V, U>
        where V : IMove<W, T, U, V>
        where W : IState<T, U, V, W>
    {
        T Options { get; }
        U CurrentPlayer { get; }

        bool IsEndState(out List<U> winningPlayers);
        //IPlayer GetWinningPlayer();

        W ApplyMove(U currentPlayer, V newMove);
    }
}
