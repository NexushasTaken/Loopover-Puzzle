using System;
using System.Collections.Generic;
using System.Text;

namespace Loopover_Puzzle.Game
{
    class Core
    {
        private readonly Random rand = new Random();
        private readonly string[] letters = {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
                "Q", "R", "S", "T", "U", "V", "W", "X", "Y"
            };

        public string[][] GenerateSolve(int size)
        {
            if (size > 5) throw new Exception($"Size should be lessthan or equal to 5, {size} is Invalid!");

            string[][] puzzle = new string[size][];
            int letter = 0;

            for (int i = 0; i < size; ++i)
            {
                string[] temp = new string[size];
                for (int j = 0; j < size; ++j)
                    temp[j] = letters[letter++];
                puzzle[i] = temp;
            }
            return puzzle;
        }

        public string[][] GenerateRandom(int size)
        {
            if (size > 5) throw new Exception($"Size should be lessthan or equal to 5, {size} is Invalid!");
            string[][] puzzle = new string[size][];
            GenerateRandom(puzzle);
            return puzzle;
        }

        public void PrintPuzzle(string[][] arr, int x, int y)
        {
            int size = arr.Length;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == y && j == x)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write((arr[i][j] == null ? "null" : arr[i][j]) + " ");
                }
                Console.WriteLine();
            }
        }

        public string[][] GenerateRandom(string[][] arr)
        {
            int size = arr.Length;
            Dictionary<int, string> dic = new Dictionary<int, string>();
            for (int i = 0; i < size; ++i)
            {
                string[] temp = new string[size];
                for (int j = 0; j < size; ++j)
                {
                    int index;
                    do
                    {
                        index = rand.Next(0, size * size);
                    } while (dic.ContainsKey(index));
                    dic.Add(index, letters[index]);
                    temp[j] = letters[index];
                }
                arr[i] = temp;
            }
            return arr;
        }

        public bool IsSolve(string[][] arr)
        {
            int size = arr.Length;
            int count = 0;
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j, ++count)
                {
                    //Console.WriteLine(letters[count] + " == " + arr[i][j] + " = " + letters[count].Equals(arr[i][j]));
                    if (!letters[count].Equals(arr[i][j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void Move(string[] arr, char move)
        {
            if (move == '<')
            {
                for (int i = 1; i < arr.Length; ++i)
                {
                    string temp = arr[i];
                    arr[i] = arr[0];
                    arr[0] = temp;
                }
                return;
            }
            int last = arr.Length - 1;
            for (int i = arr.Length - 1; i >= 0; --i)
            {
                string temp = arr[i];
                arr[i] = arr[last];
                arr[last] = temp;
            }
        }

        public void Move(string[][] arr, char move, int column)
        {
            // > == up, < == down
            if (move == '<')
            {
                for (int i = 0; i < arr.Length; ++i)
                {
                    string temp = arr[i][column];
                    arr[i][column] = arr[0][column];
                    arr[0][column] = temp;
                }
                return;
            }
            int bottom = arr.Length - 1;
            for (int i = arr.Length - 1; i >= 0; --i)
            {
                string temp = arr[i][column];
                arr[i][column] = arr[bottom][column];
                arr[bottom][column] = temp;
            }
        }

        public int CalcPos(int x, int y, Direction direction, int size)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (y > 0)
                        return --y;
                    else
                        return size - 1;
                case Direction.Down:
                    if (y < size - 1)
                        return ++y;
                    break;
                case Direction.Left:
                    if (x > 0)
                        return --x;
                    else
                        return size - 1;
                case Direction.Rigth:
                    if (x < size - 1)
                        return ++x;
                    break;
            }
            return 0;
        }

        public void PrintHelp()
        {
            Console.WriteLine("How to play");
            Console.WriteLine("Your task is to solve the puzzle in ascending order like this");
            Console.WriteLine("A B C D");
            Console.WriteLine("E F G H");
            Console.WriteLine("I J K L");
            Console.WriteLine("M N O P");
            Console.WriteLine("The board size is depends on what you want, size 2 to 5\n");
            Console.WriteLine("Use controls to solve the puzzle");
            Console.WriteLine("Notice the green highlighted letter, that is where your cursor is");
            Console.WriteLine("If you press W, letters in that column will move up");
            Console.WriteLine("If you press S, letters in that column will move down");
            Console.WriteLine("If you press A, letters in that row will move left");
            Console.WriteLine("If you press D, letters in that row will move rigth");
            Console.WriteLine("\nControls");
            Console.WriteLine("Press WASD(Up,Left,Down,Rigth) to move letters");
            Console.WriteLine("Press IJKL(Up,Left,Down,Rigth) to move the cursor");
            Console.WriteLine("Press Z to reset");
            Console.WriteLine("Press X to create new game");
            Console.WriteLine("Press C to show help menu");
            Console.WriteLine("Press Enter to exit Help menu");
            Console.WriteLine("\n\nAdditional:\nCustomizable ui and controls in next update i guess");
            Console.WriteLine("You get stuck? Well you are not smart enough :v to solve this");
            Console.WriteLine("Size 2 is super easy but in Size 3 above is hard even me i can't solve it :v");
            Console.WriteLine("Dm me if something wen't wrong i guess");
            Console.WriteLine("Well have fun! Lol!");
        }
    }
}
