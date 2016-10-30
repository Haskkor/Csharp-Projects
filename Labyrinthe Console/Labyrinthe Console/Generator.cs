using System;
using System.Collections.Generic;

namespace Labyrinthe_Console
{
    class Generator
    {
        private readonly int _width;
        private readonly int _height;
        private int _nbLabyrinths;
        public Cell[,] Laby;
        readonly List<Coordinates> _listCoord = new List<Coordinates>();
        private readonly Random _random = new Random(DateTime.Now.Millisecond);
        public String MazeFileName;

        public Generator(int width, int height, String fileName)
        {
            MazeFileName = fileName + ".txt";
            if (width % 2 == 0)
            {
                _width = width + 1;
            }
            else _width = width + 2;
            if (height%2 == 0)
            {
                _height = height + 1;
            }
            else _width = width + 2;
            Laby = new Cell[_width, _height];
            GenBase();
            GenMaze();
	    }

        public Generator(int nbLabys, int width, int height, String fileName) 
        {
		    _nbLabyrinths = nbLabys;
            if (width % 2 == 0)
            {
                _width = width + 1;
            }
            else _width = width + 2;
            if (height % 2 == 0)
            {
                _height = height + 1;
            }
            else _width = width + 2;
            Laby = new Cell[_width, _height];
            for (int i = 0; i < _nbLabyrinths; i++)
            {
                GenBase();
                GenMaze();
                MazeFileName = "\\Zips\\" + fileName + i + ".txt";
                FilesZipOps.StringMaze(Laby, MazeFileName);
            }
            FilesZipOps.ZipMazes(fileName);
	    }

        public void GenBase()
        {

            // Initialisation des bords du tableau en tant que murs.
            for (int i = 0; i < _width; i++)
            {
                Laby[i, 0] = new Cell("X");
            }
            if (_height % 2 != 2)
            {
                for (int i = 0; i < _width; i++)
                {
                    Laby[i, _height - 1] = new Cell("X");
                }
            }
            for (int i = 0; i < _height; i++)
            {
                Laby[0, i] = new Cell("X");
            }
            if (_width%2 != 0)
            {
                for (int i = 0; i < _height; i++)
                {
                    Laby[_width - 1, i] = new Cell("X");
                }
            }
            
            // Initialisation des cases du tableau.

            bool wall = false;
            for (int i = 1; i < _width - 1; i++)
            {
                if (i%2 == 0)
                {
                    for (int j = 1; j < _height - 1; j++)
                    {
                        Laby[i, j] = new Cell("#");
                    }
                }
                else
                {
                    for (int j = 1; j < _height - 1; j++)
                    {
                        if (wall)
                        {
                            Laby[i, j] = new Cell("#");
                        }
                        else
                        {
                            Laby[i, j] = new Cell(" ");
                            _listCoord.Add(new Coordinates(i, j));
                        }
                        wall = !wall;
                    }
                    wall = false;
                }
            }
        }

        public void GenMaze()
        {
            // Choix aléatoire d'une cellule du tableau.
            StartEndCell();
            while (_listCoord.Count > 0)
            {
                const int lower = 0;
                int higher = _listCoord.Count;
                int randomCoord = _random.Next(lower, higher);
                //Console.WriteLine(this.listeCoord.Count);
                CellChoice(_listCoord[randomCoord]);
                _listCoord.RemoveAt(randomCoord);
            }
        }

        // Traitement d'une cellule. Ouverture d'un mur au hasard.
        public void CellChoice(Coordinates coord)
        {
            bool ouest = false;
            bool est = false;
            bool nord = false;
            bool sud = false;
            bool wallOpen = false;
            while (!wallOpen)
            {
                int randomCard = _random.Next(0, 4);
                if (ouest && est && nord && sud)
                {
                    wallOpen = true;
                }
                switch (randomCard)
                {
                    // Ouest.
                    case 0:
                        if (coord.Col - 2 >= 1)
                        {
                            if (Laby[coord.Col, coord.Row].Id != Laby[coord.Col - 2, coord.Row].Id)
                            {
                                //Console.WriteLine("Ouest");
                                Laby[coord.Col - 2, coord.Row].Id = Laby[coord.Col, coord.Row].Id;
                                Laby[coord.Col, coord.Row].ListNeighbours.Add(new Coordinates(coord.Col - 2,
                                    coord.Row));
                                Laby[coord.Col - 2, coord.Row].ListNeighbours.Add(new Coordinates(coord.Col,
                                    coord.Row));
                                foreach (var coordin in Laby[coord.Col, coord.Row].ListNeighbours)
                                {
                                    Laby[coord.Col - 2, coord.Row].ListNeighbours.Add(coordin);
                                }
                                foreach (var coordin in Laby[coord.Col - 2, coord.Row].ListNeighbours)
                                {
                                    Laby[coord.Col, coord.Row].ListNeighbours.Add(coordin);
                                }
                                foreach (var coordin in Laby[coord.Col, coord.Row].ListNeighbours)
                                {
                                    Laby[coordin.Col, coordin.Row].ListNeighbours =
                                        Laby[coord.Col, coord.Row].ListNeighbours;
                                    Laby[coordin.Col, coordin.Row].Id = Laby[coord.Col, coord.Row].Id;
                                }
                                Laby[coord.Col - 1, coord.Row].Type = " ";
                                wallOpen = true;
                            }
                        }
                        ouest = true;
                        break;
                    // Est.
                    case 1 :
                        if (coord.Col + 2 < _width)
                        {
                            if (Laby[coord.Col, coord.Row].Id != Laby[coord.Col + 2, coord.Row].Id)
                            {
                                //Console.WriteLine("Est");
                                Laby[coord.Col + 2, coord.Row].Id = Laby[coord.Col, coord.Row].Id;
                                Laby[coord.Col, coord.Row].ListNeighbours.Add(new Coordinates(coord.Col + 2,
                                    coord.Row));
                                Laby[coord.Col + 2, coord.Row].ListNeighbours.Add(new Coordinates(coord.Col,
                                    coord.Row));
                                foreach (var coordin in Laby[coord.Col, coord.Row].ListNeighbours)
                                {
                                    Laby[coord.Col + 2, coord.Row].ListNeighbours.Add(coordin);
                                }
                                foreach (var coordin in Laby[coord.Col + 2, coord.Row].ListNeighbours)
                                {
                                    Laby[coord.Col, coord.Row].ListNeighbours.Add(coordin);
                                }
                                foreach (var coordin in Laby[coord.Col, coord.Row].ListNeighbours)
                                {
                                    Laby[coordin.Col, coordin.Row].ListNeighbours =
                                        Laby[coord.Col, coord.Row].ListNeighbours;
                                    Laby[coordin.Col, coordin.Row].Id = Laby[coord.Col, coord.Row].Id;
                                }
                                Laby[coord.Col + 1, coord.Row].Type = " ";
                                wallOpen = true;
                            }
                        }
                        est = true;
                        break;
                    // Nord.
                    case 2:
                        if (coord.Row - 2 >= 1)
                        {
                            if (Laby[coord.Col, coord.Row].Id != Laby[coord.Col, coord.Row - 2].Id)
                            {
                                //Console.WriteLine("Nord");
                                Laby[coord.Col, coord.Row - 2].Id = Laby[coord.Col, coord.Row].Id;
                                Laby[coord.Col, coord.Row].ListNeighbours.Add(new Coordinates(coord.Col,
                                    coord.Row - 2));
                                Laby[coord.Col, coord.Row - 2].ListNeighbours.Add(new Coordinates(coord.Col,
                                    coord.Row));
                                foreach (var coordin in Laby[coord.Col, coord.Row].ListNeighbours)
                                {
                                    Laby[coord.Col, coord.Row - 2].ListNeighbours.Add(coordin);
                                }
                                foreach (var coordin in Laby[coord.Col, coord.Row - 2].ListNeighbours)
                                {
                                    Laby[coord.Col, coord.Row].ListNeighbours.Add(coordin);
                                }
                                foreach (var coordin in Laby[coord.Col, coord.Row].ListNeighbours)
                                {
                                    Laby[coordin.Col, coordin.Row].ListNeighbours =
                                        Laby[coord.Col, coord.Row].ListNeighbours;
                                    Laby[coordin.Col, coordin.Row].Id = Laby[coord.Col, coord.Row].Id;
                                }
                                Laby[coord.Col, coord.Row - 1].Type = " ";
                                wallOpen = true;
                            }
                        }
                        nord = true;
                        break;
                    // Sud.
                    case 3:
                        if (coord.Row + 2 < _height)
                        {
                            if (Laby[coord.Col, coord.Row].Id != Laby[coord.Col, coord.Row + 2].Id)
                            {
                                //Console.WriteLine("Sud");
                                Laby[coord.Col, coord.Row + 2].Id = Laby[coord.Col, coord.Row].Id;
                                Laby[coord.Col, coord.Row].ListNeighbours.Add(new Coordinates(coord.Col,
                                    coord.Row + 2));
                                Laby[coord.Col, coord.Row + 2].ListNeighbours.Add(new Coordinates(coord.Col,
                                    coord.Row));
                                foreach (var coordin in Laby[coord.Col, coord.Row].ListNeighbours)
                                {
                                    Laby[coord.Col, coord.Row + 2].ListNeighbours.Add(coordin);
                                }
                                foreach (var coordin in Laby[coord.Col, coord.Row + 2].ListNeighbours)
                                {
                                    Laby[coord.Col, coord.Row].ListNeighbours.Add(coordin);
                                }
                                foreach (var coordin in Laby[coord.Col, coord.Row].ListNeighbours)
                                {
                                    Laby[coordin.Col, coordin.Row].ListNeighbours =
                                        Laby[coord.Col, coord.Row].ListNeighbours;
                                    Laby[coordin.Col, coordin.Row].Id = Laby[coord.Col, coord.Row].Id;
                                }
                                Laby[coord.Col, coord.Row + 1].Type = " ";
                                wallOpen = true;
                            }
                        }
                        sud = true;
                        break;
                    default:
                        wallOpen = true;
                        break;
                }
            }
        }

        public void StartEndCell()
        {
            const int lower = 0;
            int higher = _listCoord.Count;
            int randomCoord = _random.Next(lower, higher);
            Laby[_listCoord[randomCoord].Col, _listCoord[randomCoord].Row].Type = "S";
            randomCoord = _random.Next(lower, higher);
            Laby[_listCoord[randomCoord].Col, _listCoord[randomCoord].Row].Type = "G";
        }
    }
}