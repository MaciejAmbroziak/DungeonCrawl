using Codecool.DungeonCrawl.Logic.Actors;
using Perlin.Display;

namespace Codecool.DungeonCrawl.Logic
{
    /// <summary>
    ///     Represents a cell in the map.
    /// </summary>
    public class Cell
    {
        /// <summary>
        ///     The actor on the cell, null of none.
        /// </summary>
        public Actor Actor;

        /// <summary>
        ///     Type of the cell
        /// </summary>
        public CellType Type;

        public Cell(int x, int y, DisplayObject parent, CellType type)
        {
            Type = type;
            Sprite = new Sprite("tiles.png", false, TileSet.GetCellTile(Type));
            Sprite.ScaleX = Sprite.ScaleY = TileSet.Scale;

            Position = (x, y);
            parent.AddChild(Sprite);
        }

        public string Tilename => Type.ToString();

        public Sprite Sprite { get; set; }

        public (float x, float y) Position
        {
            get => (Sprite.X / TileSet.Size / TileSet.Scale, Sprite.Y / TileSet.Size / TileSet.Scale);
            set
            {
                Sprite.X = value.x * TileSet.Size * TileSet.Scale;
                Sprite.Y = value.y * TileSet.Size * TileSet.Scale;
            }
        }

        /// <summary>
        ///     Returns a cell in the given distance
        /// </summary>
        /// <param name="dx">X distance from this cell</param>
        /// <param name="dy">Y distance from this cell</param>
        /// <returns>The cell in the given distance</returns>
        public Cell GetNeighbor(int dx, int dy)
        {
            return null;
            // return _gameMap.GetCell(X + dx, Y + dy);
        }
    }
}