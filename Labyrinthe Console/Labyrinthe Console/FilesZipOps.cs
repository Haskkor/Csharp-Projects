using System;
using System.IO;
using System.IO.Compression;

namespace Labyrinthe_Console
{
    class FilesZipOps
    {
        static String _labyString = null;

        private const String Path =
            @"C:\Users\Jérémy\Documents\Visual Studio 2012\Projects\Labyrinthe Console\Fichiers Save\";

        public static void StringMaze(Cell[,] maze, String filename)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    _labyString = _labyString + (maze[i, j].Type);
                }
                _labyString = _labyString + "\r\n";
            }

            File.WriteAllText(Path + filename, _labyString);

            _labyString = null;
        }

        public static void ZipMazes(String zipname)
        {
            ZipFile.CreateFromDirectory(Path + "\\Zips", Path + "\\" + zipname + ".zip");
            foreach (var file in Directory.GetFiles(Path + "\\Zips"))
            {
                File.Delete(file);
            }
        }
    }
}