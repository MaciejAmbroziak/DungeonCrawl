using System.IO;
using Codecool.DungeonCrawl.Logic.Actors;
using Perlin.Display;

namespace Codecool.DungeonCrawl.Logic
{
    /// <summary>
    ///     Helper class to load the map from the disk
    /// </summary>
    public static class MapLoader
    {
        /// <summary>
        ///     Returns map's dimensions
        /// </summary>
        /// <returns></returns>
        public static (int width, int height) GetMapDimensions()
        {
            var lines = File.ReadAllLines("map.txt");
            var dimensions = lines[0].Split(" ");
            var width = int.Parse(dimensions[0]);
            var height = int.Parse(dimensions[1]);

            return (width, height);
        }

        /// <summary>
        ///     Loads and returns the GameMap
        /// </summary>
        /// <param name="cellParent"></param>
        /// <returns></returns>
        public static Cell[,] LoadMap(DisplayObject cellParent)
        {
            var lines = File.ReadAllLines("map.txt");
            var dimensions = lines[0].Split(" ");
            var width = int.Parse(dimensions[0]);
            var height = int.Parse(dimensions[1]);

            var cellGrid = new Cell[width, height];

            for (var y = 0; y < height; y++)
            {
                var line = lines[y + 1];
                for (var x = 0; x < width; x++)
                {
                    var character = line[x];

                    // Cell type assignment
                    var cellType = GetCellType(character);
                    var cell = new Cell(x, y, cellParent, cellType);

                    // Actor creation and assignment
                    cell.Actor = GetActor(character, cell);

                    cellGrid[x, y] = cell;
                }
            }

            return cellGrid;
        }

        /// <summary>
        ///     Assigns Cell Type based on given character
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static CellType GetCellType(char c) => c switch
        {
            ' ' => CellType.Empty,
            '#' => CellType.Wall,
            _ => CellType.Empty
        };

        /// <summary>
        ///     Assigns Actor based on given character
        /// </summary>
        /// <param name="c"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static Actor GetActor(char c, Cell cell) => c switch
        {
            's' => new Skeleton(cell),
            'p' => new Player(cell),
            _ => null
        };
    }
}