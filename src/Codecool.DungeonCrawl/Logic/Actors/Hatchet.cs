using Codecool.DungeonCrawl.Logic.Map;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    class Hatchet : Actor
    {
        public Hatchet(Cell cell) : base(cell, TileSet.GetTile(TileType.Hatchet))
        {
        }
        public override bool OnCollision(Actor other)
        {
            if (other is Player)
            {
                if(!other.hasHatchet);
                    this.Destroy();
                    other.hasHatchet = true;
                    return true;
            }
            return false;
        }
    }
}