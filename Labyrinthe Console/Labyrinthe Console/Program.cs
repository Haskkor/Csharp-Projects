using System.Threading;

namespace Labyrinthe_Console
{
    class Program
    {
        static void Main()
        {
            var maze = new Generator(20, 20,"Maze1");
            var mazes = new Generator(5, 20, 20, "Mazes");
            var cons = new ConsoleOut();

            cons.PrintMaze(maze.Laby);
            FilesZipOps.StringMaze(maze.Laby, maze.MazeFileName);
            Thread.Sleep(100000);
        }
    }
}
