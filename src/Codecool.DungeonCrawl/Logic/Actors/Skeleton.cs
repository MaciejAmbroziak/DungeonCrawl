using Codecool.DungeonCrawl.Logic.Map;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    ///     Sample enemy
    /// </summary>
    public class Skeleton : Actor
    {
        public Skeleton(Cell cell) : base(cell, TileSet.GetTile(TileType.Skeleton))
        {
            // TODO
        }

        public override bool OnCollision(Actor other)
        {
            // TODO receive damage logic
            return false;
        }
    }
}