using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Engine.Interfaces
{
    public interface IState<T> where T : IGameOptions
    {
        bool IsEndState(out List<IPlayer> winningPlayers);
        //IPlayer GetWinningPlayer();

        IState<T> ApplyMove(IMove newMove);
    }
}
