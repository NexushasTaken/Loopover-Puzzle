using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loopover_Puzzle.Game
{
    class Loopover
    {
        bool win;
        bool start;
        bool help;
        int size;
        Core core;
        string[][] puzzle;
        int x;
        int y;

        public Loopover()
        {
            core = new Core();
            start = true;
            win = false;
            help = true;
            x = y = 0;
            Game();
        }

        void Game()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (help)
                {
                    Console.Clear();
                    core.PrintHelp();
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                        help = false;
                }
                else
                {
                    Console.Clear();
                    if (start)
                    {
                        GetSize();
                        puzzle = core.GenerateRandom(size);
                        if (core.IsSolve(puzzle))
                            continue;
                        start = false;
                        Console.Clear();
                    }
                    if (core.IsSolve(puzzle))
                    {
                        Console.WriteLine("You solve the puzzle!! GG!!");
                        win = true;
                    }
                    core.PrintPuzzle(puzzle, x, y);
                    ConsoleKey key = Console.ReadKey().Key;
                    switch (key)
                    {
                        // Move Cursor
                        case ConsoleKey.I:
                            if (!win)
                            {
                                if (y > 0)
                                    --y;
                                else
                                    y = size - 1;
                            }
                            break;
                        case ConsoleKey.K:
                            if (!win)
                            {
                                if (y < size - 1)
                                    ++y;
                                else
                                    y = 0;
                            }
                            break;

                        case ConsoleKey.J:
                            if (!win)
                            {
                                if (x > 0)
                                    --x;
                                else
                                    x = size - 1;
                            }
                            break;
                        case ConsoleKey.L:
                            if (!win)
                            {
                                if (x < size - 1)
                                    ++x;
                                else
                                    x = 0;
                            }
                            break;

                        // Cling
                        case ConsoleKey.W:
                            if (!win)
                            {
                                core.Move(puzzle, '>', x);
                                y = core.CalcPos(x, y, Direction.Up, size);
                            }
                            break;
                        case ConsoleKey.A:
                            if (!win)
                            {
                                core.Move(puzzle[y], '>');
                                x = core.CalcPos(x, y, Direction.Left, size);
                            }
                            break;
                        case ConsoleKey.S:
                            if (!win)
                            {
                                core.Move(puzzle, '<', x);
                                y = core.CalcPos(x, y, Direction.Down, size);
                            }
                            break;
                        case ConsoleKey.D:
                            if (!win)
                            {
                                core.Move(puzzle[y], '<');
                                x = core.CalcPos(x, y, Direction.Rigth, size);
                            }
                            break;
                        case ConsoleKey.Z:
                            // Reset
                            puzzle = core.GenerateRandom(size);
                            win = false;
                            break;
                        case ConsoleKey.X:
                            // Size
                            start = true;
                            x = 0;
                            y = 0;
                            break;
                        case ConsoleKey.C:
                            help = true;
                            break;
                    }
                }
            }
        }

        void GetSize()
        {
            try
            {
                while (true)
                {
                    Console.Write("Enter size(2-5): ");
                    size = Convert.ToInt32(Console.ReadLine());
                    if (size < 2 || size > 5)
                        Console.WriteLine($"Size should be 2-5, not {size}");
                    else
                        return;
                }
            }
            catch
            {
                GetSize();
            }
        }

        //I don't know how to use asynchronous XD
        //private async Task Exit()
        //private async Task Exit()
        //{
        //    Task task = new Task(() =>
        //    {
        //        while (true)
        //            if (Console.ReadKey().Key == ConsoleKey.Escape)
        //                Environment.Exit(0);
        //    });
        //    task.Start();
        //}

    }
}
