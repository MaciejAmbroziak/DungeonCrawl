using System.Collections.Generic;
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
        public const int Scale = 2;

        private static readonly Dictionary<TileType, Rectangle> TileMap;

        static TileSet()
        {
            TileMap = new Dictionary<TileType, Rectangle>
            {
                [TileType.Empty] = CreateTile(0, 0),
                [TileType.Wall] = CreateTile(10, 17),
                [TileType.Floor] = CreateTile(2, 0),
                [TileType.Player] = CreateTile(27, 0),
                [TileType.Skeleton] = CreateTile(29, 6),
                [TileType.Portal] = CreateTile(22,11),
                [TileType.Sword] = CreateTile(3, 29),
                [TileType.Health] = CreateTile(27, 23),
                [TileType.Chicken] = CreateTile(26,7),
                [TileType.Egg] = CreateTile(18, 29),
                [TileType.Troll] = CreateTile(30,6),
                [TileType.Bush] = CreateTile(1,2),
                [TileType.Hatchet] = CreateTile(10,29),
                [TileType.Shield] = CreateTile(7,26),
                [TileType.Door] = CreateTile(4, 9),
                [TileType.DoorKey] = CreateTile(16, 23)
            };
        }

        /// <summary>
        ///     Returns tile rectange for given TileType
        /// </summary>
        /// <param name="tileType"></param>
        /// <returns></returns>
        public static Rectangle GetTile(TileType tileType)
        {
            return TileMap[tileType];
        }

        private static Rectangle CreateTile(int i, int j)
        {
            return new Rectangle(i * (Size + 1), j * (Size + 1), Size, Size);
        }
    }
}