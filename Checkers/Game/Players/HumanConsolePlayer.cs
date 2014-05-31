using Checkers.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Game.Players
{
    public class HumanConsolePlayer : CheckersPlayer
    {
        public HumanConsolePlayer(Team team, CheckersOptions options)
        {
            Team = team;
            Options = options;

            //CurrentState = new CheckersState(Options);
        }

        public override void UpdateState(List<CheckersMove> moves)
        {
            foreach (var move in moves)
            {
                if (move == null)
                {
                    continue;
                }

                CurrentState = CurrentState.ApplyMove(move);
            }

            List<CheckersPlayer> winningPlayers;
            if (CurrentState.IsEndState(out winningPlayers))
            {
                if (winningPlayers.Count == 0 || winningPlayers.Count > 1)
                {
                    Console.WriteLine("The game is over.  It was a draw.");
                }
                else if (winningPlayers[0] == this)
                {
                    Console.WriteLine("You won!");
                }
                else
                {
                    Console.WriteLine("You lost.");
                }

                PrintState(CurrentState);
            }
        }

        public override CheckersMove GetMove()
        {
            if (CurrentState == null)
            {
                Console.WriteLine("The current state is unknown.");
            }
            else
            {
                Console.WriteLine("This is the current state. {0}'s turn.", CurrentState.CurrentPlayer.Team.ToString());
                PrintState(CurrentState);

                System.Console.WriteLine();
            }

            // TODO: Error checking and making sure the entered locations are valid.

            int pieceRow = -1;
            int pieceColumn = -1;

            CheckersMove previousMove = null;
            Moves.JumpPieceMove previousJumpMove = null;
            if (CurrentState.MovesThisTurn.Count > 0)
            {
                previousMove = CurrentState.MovesThisTurn[CurrentState.MovesThisTurn.Count - 1];
            }

            if (previousMove is Moves.JumpPieceMove)
            {
                previousJumpMove = previousMove as Moves.JumpPieceMove;
                pieceRow = previousJumpMove.EndRow;
                pieceColumn = previousJumpMove.EndColumn;

                System.Console.WriteLine("You must either jump again with the piece located at {0}, {1}, or enter nothing to end your turn.",
                    pieceRow, pieceColumn);
            }
            else
            {
                System.Console.Write("Please enter the row of the piece to move: ");
                pieceRow = System.Console.ReadLine()[0] - Convert.ToInt32('0');

                System.Console.Write("Please enter the column of the piece to move: ");
                pieceColumn = System.Console.ReadLine()[0] - Convert.ToInt32('0');
            }

            System.Console.Write("Please enter the row of the location to move to: ");
            var lineEntered = System.Console.ReadLine();
            if (lineEntered.Length == 0 && previousJumpMove != null)
            {
                return new Moves.EndTurnMove(this);
            }

            char firstCharacterEntered = lineEntered[0];
            int destinationRow = firstCharacterEntered - Convert.ToInt32('0');

            System.Console.Write("Please enter the column of the location to move to: ");
            int destinationColumn = System.Console.ReadLine()[0] - Convert.ToInt32('0');

            int rowDelta = Math.Abs(pieceRow - destinationRow);
            Piece movingPiece = CurrentState.Board[pieceRow * CurrentState.Options.NumColumns + pieceColumn].Piece;
            if (rowDelta == 1 && previousJumpMove == null)
            {
                return new Moves.SlidePieceMove(pieceRow, pieceColumn, destinationRow,
                    destinationColumn, movingPiece, this);
            }
            else if (rowDelta == 2)
            {
                int opponentPieceRow = pieceRow + ((destinationRow - pieceRow) / 2);
                int opponentPieceColumn = pieceColumn + ((destinationColumn - pieceColumn) / 2);
                Piece jumpedPiece = CurrentState.Board[opponentPieceRow * CurrentState.Options.NumColumns + opponentPieceColumn].Piece;

                return new Moves.JumpPieceMove(pieceRow, pieceColumn, destinationRow,
                    destinationColumn, movingPiece, jumpedPiece, this);
            }
            else
            {
                throw new InvalidOperationException();
            }

        }

        public void PrintCurrentState()
        {
            PrintState(CurrentState);
        }
    }
}
