using System;

namespace Labyrinthe_Console
{
    class ConsoleOut
    {
        public void PrintMaze(Cell[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i,j].Type);
                }
                Console.Write("\n");
            }
        }

    }
}
