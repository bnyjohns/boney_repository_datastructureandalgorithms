using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    public class NbyNQueens
    {
        private static bool[,] board = null;
        private static int boardSize = 0;
        public static bool PositionQueens(int n)
        {
            board = new bool[n, n];
            boardSize = n;
            var result = Position(n);
            if (result)
            {
                Console.WriteLine("YES");
                for (int i = 0; i < boardSize; i++)
                {
                    var row = "";
                    for (int j = 0; j < boardSize; j++)
                    {
                        row += board[i, j] ? "1" : "0";
                        if (j != boardSize - 1)
                            row += " ";
                    }
                    Console.WriteLine(row);
                }
            }                
            else
                Console.WriteLine("NO");
            return result;
        }

        private static bool Position(int pendingQueens)
        {
            if (pendingQueens == 0)
                return true;

            for (int i = (boardSize-pendingQueens); i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (IsQueenUnderAttack(i, j))
                        continue;
                    else
                        board[i, j] = true;

                    if (Position(pendingQueens - 1))
                        return true;

                    board[i, j] = false;
                }
            }
            return false;
        }

        private static bool IsQueenUnderAttack(int p, int q)
        {
            for (int j = 0; j < boardSize; j++)
            {
                if (board[p, j])
                    return true;
            }

            for (int i = 0; i < boardSize; i++)
            {
                if (board[i, q])
                    return true;
            }

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if(i-j == p-q || i + j == p + q)
                    {
                        if (board[i, j])
                            return true;
                    }                    
                }
            }
            return false;
        }
    }
}
