using System;
using System.Data;

namespace WordSearch
{
    class Program
    {
        static char[,] Grid = new char[,] {
            {'C', 'P', 'K', 'X', 'O', 'I', 'G', 'H', 'S', 'F', 'C', 'H'},
            {'Y', 'G', 'W', 'R', 'I', 'A', 'H', 'C', 'Q', 'R', 'X', 'K'},
            {'M', 'A', 'X', 'I', 'M', 'I', 'Z', 'A', 'T', 'I', 'O', 'N'},
            {'E', 'T', 'W', 'Z', 'N', 'L', 'W', 'G', 'E', 'D', 'Y', 'W'},
            {'M', 'C', 'L', 'E', 'L', 'D', 'N', 'V', 'L', 'G', 'P', 'T'},
            {'O', 'J', 'A', 'A', 'V', 'I', 'O', 'T', 'E', 'E', 'P', 'X'},
            {'C', 'D', 'B', 'P', 'H', 'I', 'A', 'W', 'V', 'X', 'U', 'I'},
            {'L', 'G', 'O', 'S', 'S', 'B', 'R', 'Q', 'I', 'A', 'P', 'K'},
            {'E', 'O', 'I', 'G', 'L', 'P', 'S', 'D', 'S', 'F', 'W', 'P'},
            {'W', 'F', 'K', 'E', 'G', 'O', 'L', 'F', 'I', 'F', 'R', 'S'},
            {'O', 'T', 'R', 'U', 'O', 'C', 'D', 'O', 'O', 'F', 'T', 'P'},
            {'C', 'A', 'R', 'P', 'E', 'T', 'R', 'W', 'N', 'G', 'V', 'Z'}
        };

        static string[] Words = new string[] 
        {
            "CARPET",
            "CHAIR",
            "DOG",
            "BALL",
            "DRIVEWAY",
            "FISHING",
            "FOODCOURT",
            "FRIDGE",
            "GOLF",
            "MAXIMIZATION",
            "PUPPY",
            "SPACE",
            "TABLE",
            "TELEVISION",
            "WELCOME",
            "WINDOW"
        };

        static int GridColumns = Grid.GetLength(1);
        static int GridRows = Grid.GetLength(0);

        static void Main(string[] args)
        {
            Console.WriteLine("Word Search");

            ShowGrid();

            Console.WriteLine("");
            Console.WriteLine("Found Words");
            Console.WriteLine("------------------------------");

            FindWords();

            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }

        // Show initial grid
        private static void ShowGrid()
        {
            for (int row = 0; row < GridRows; row++)
            {
                for (int column = 0; column < GridColumns; column++)
                {
                    Console.Write(Grid[row, column] + " ");
                }
                Console.WriteLine("");
            }
        }

        private static void FindWords()
        {
            foreach (string word in Words)
            {
                for (int row = 0; row < GridRows; row++)
                {
                    for (int column = 0; column < GridColumns; column++)
                    {
                        for (int directionRow = -1; directionRow <= 1; directionRow++)
                        {
                            for (int directionColumn = -1; directionColumn <= 1; directionColumn++)
                            {
                                // Continue when both directionColumn and directionRow are 0
                                if (directionRow == 0 && directionColumn == 0)
                                    continue;

                                // Calculate the end coordinates based on the word length and direction
                                int endRow = row + (word.Length - 1) * directionRow;
                                int endColumn = column + (word.Length - 1) * directionColumn;

                                if (IsValidCoordinate(endRow, endColumn) && CheckWord(word, row, column, directionRow, directionColumn))
                                {
                                    // Display results, the word and its start and end coordinates
                                    Console.WriteLine($"{word} found at ({column}, {row}) to ({endColumn}, {endRow})");
                                }
                            }
                        }
                    }
                }
            }
        }

        // Check valid cordinates
        private static bool IsValidCoordinate(int row, int column)
        {
            return row >= 0 && row < GridRows && column >= 0 && column < GridColumns;
        }

        private static bool CheckWord(string word, int startRow, int startColumn, int directionRow, int directionColumn)
        {
            // Calculate the end coordinates
            int endRow = startRow + (word.Length - 1) * directionRow;
            int endColumn = startColumn + (word.Length - 1) * directionColumn;

            // Validate end coordinates are valid
            if (!IsValidCoordinate(endRow, endColumn))
                return false;

            // Varify word against the position in the grid
            for (int i = 0; i < word.Length; i++)
            {
                int currentRow = startRow + i * directionRow;
                int currentColumn = startColumn + i * directionColumn;

                // Verify if mismatched
                if (Grid[currentRow, currentColumn] != word[i])
                    return false;
            }

            // Validte characters
            return true;
        }
    }
}
