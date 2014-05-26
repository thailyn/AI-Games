using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Engine.Interfaces
{
    public interface IMove
    {
        List<IMove> Steps { get; }
        IPlayer PerformingPlayer { get; set; }
    }
}
