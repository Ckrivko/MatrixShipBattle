using System;
using System.Collections.Generic;
using System.Linq;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            string[] coordinates = Console.ReadLine().Split(",").ToArray();

            int playerOne = 0;
            int playerTwo = 0;

            int totalShips = 0;

            for (int row = 0; row < n; row++)
            {
                string inputFirst = Console.ReadLine();

                char[] input = inputFirst.Where(x => !Char.IsWhiteSpace(x)).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            for (int row = 0; row < n; row++) //намирам  корабите
            {

                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == '<')
                    {
                        playerOne++;
                    }
                    if (matrix[row, col] == '>')
                    {
                        playerTwo++;
                    }
                }
            }

            for (int i = 0; i < coordinates.Length; i++)
            {

                int[] currInt = coordinates[i].Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int row = currInt[0];
                int col = currInt[1];

                if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
                {
                    continue;
                }

                if (matrix[row, col] == '<')
                {
                    playerOne--;
                    totalShips++;
                    matrix[row, col] = 'X';
                }

                if (matrix[row, col] == '>')
                {

                    playerTwo--;
                    totalShips++;
                    matrix[row, col] = 'X';
                }


                if (matrix[row, col] == '#')
                {
                    for (int iRow = row - 1; iRow < 3; iRow++)
                    {
                        for (int iCol = col - 1; iCol < 3; iCol++)
                        {
                            if (iRow >= 0 && iCol >= 0 && iRow < matrix.GetLength(0) && iCol < matrix.GetLength(1))
                            {
                                if (matrix[iRow, iCol] == '<')
                                {
                                    playerOne--;
                                    totalShips++;
                                    matrix[iRow, iCol] = 'X';
                                }
                                if (matrix[iRow, iCol] == '>')
                                {
                                    playerTwo--;
                                    totalShips++;
                                    matrix[iRow, iCol] = 'X';
                                }

                            }

                        }
                    }

                    matrix[row, col] = 'X';

                }


                if (playerOne == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {totalShips} ships have been sunk in the battle.");
                    return;
                }
                else if (playerTwo == 0)
                {
                    Console.WriteLine($"Player One has won the game! {totalShips} ships have been sunk in the battle.");
                    return;
                }

            }


            Console.WriteLine($"It's a draw! Player One has {playerOne} ships left. Player Two has {playerTwo} ships left.");
        }

        

        
        


    }
}

