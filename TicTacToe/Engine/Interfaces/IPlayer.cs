using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Engine.Interfaces
{
    public interface IPlayer
    {
        void UpdateState(List<IMove> moves);
        IMove GetMove();
    }
}
