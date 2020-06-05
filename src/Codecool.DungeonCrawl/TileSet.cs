using System.Collections.Generic;
using Codecool.DungeonCrawl.Logic;
using Perlin.Geom;

namespace Codecool.DungeonCrawl
{
    /// <summary>
    ///     Helper class to read the tile map image.
    /// </summary>
    public static class TileSet
    {
        /// <summary>
        ///     Size of a single tile in pixels
        /// </summary>
        public const int Size = 16;

        /// <summary>
        ///     Scale of the game (used as a multiplier)
        /// </summary>
        public const int Scale = 3;

        public static readonly Rectangle PlayerTile;
        public static readonly Rectangle SkeletonTile;

        private static readonly Dictionary<CellType, Rectangle> TileMap;

        static TileSet()
        {
            TileMap = new Dictionary<CellType, Rectangle>
            {
                [CellType.Empty] = CreateTile(0, 0),
                [CellType.Wall] = CreateTile(10, 17),
                [CellType.Floor] = CreateTile(2, 0)
            };

            PlayerTile = CreateTile(27, 0);
            SkeletonTile = CreateTile(29, 6);
        }

        public static Rectangle GetCellTile(CellType cellType)
        {
            return TileMap[cellType];
        }

        private static Rectangle CreateTile(int i, int j)
        {
            return new Rectangle(i * (Size + 1), j * (Size + 1), Size, Size);
        }
    }
}