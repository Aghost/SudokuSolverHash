using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SudokuSolver.Logics
{
    class HashSolver
    {
        static HashSet<char>[] rows = new HashSet<char>[9];
        static HashSet<char>[] cols = new HashSet<char>[9];
        static HashSet<char>[] boxs = new HashSet<char>[9];

        static public int[][] SolveSudoku(char[][] board)
        {
            FillHashSets(board);
            Solve(board, 0, 0);

            return CharToJagInt(board, 9);
        }

        static bool Solve(char[][] board, int i, int j)
        {
            for (int k = i; k < 9; k++)
            {
                for (int l = j; l < 9; l++)
                {
                    if (board[k][l] != '0')
                        continue;

                    for (int n = 49; n <= 57; n++)
                    {
                        char num = (char)n;

                        if (!rows[k].Contains(num) &&
                                !cols[l].Contains(num) &&
                                !boxs[(k / 3) * 3 + (l / 3)].Contains(num))
                        {
                            board[k][l] = num;
                            rows[k].Add(num);
                            cols[l].Add(num);
                            boxs[(k / 3) * 3 + (l / 3)].Add(num);

                            if (Solve(board, k, l))
                                return true;

                            board[k][l] = '0';

                            rows[k].Remove(num);
                            cols[l].Remove(num);
                            boxs[(k / 3) * 3 + (l / 3)].Remove(num);
                        }
                    }

                    if (board[k][l] == '0')
                        return false;
                }
                j = 0;
            }
            return true;
        }

        public static char[][] IntToJagChar(int[][] board, int len)
        {
            char[][] charBoard = new char[len][];

            for (int i = 0; i < len; i++)
                charBoard[i] = new char[len];

            for (int i = 0; i < len; i++)
                for (int j = 0; j < len; j++)
                    charBoard[i][j] = (char)(board[i][j] + 48);

            return charBoard;
        }

        public static int[][] CharToJagInt(char[][] board, int len)
        {
            int[][] intBoard = new int[len][];

            for (int i = 0; i < len; i++)
                intBoard[i] = new int[len];

            for (int i = 0; i < len; i++)
                for (int j = 0; j < len; j++)
                    intBoard[i][j] = (board[i][j] - 48);

            return intBoard;
        }

        static void FillHashSets(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                rows[i] = new HashSet<char>();
                cols[i] = new HashSet<char>();
                boxs[i] = new HashSet<char>();
            }

            foreach (HashSet<char> row in rows)
                row.Clear();
            foreach (HashSet<char> col in cols)
                col.Clear();
            foreach (HashSet<char> box in boxs)
                box.Clear();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '0')
                        continue;

                    int s = (i / 3) * 3 + (j / 3);

                    rows[i].Add(board[i][j]);
                    cols[j].Add(board[i][j]);
                    boxs[s].Add(board[i][j]);
                }
            }
        }
    }
}
