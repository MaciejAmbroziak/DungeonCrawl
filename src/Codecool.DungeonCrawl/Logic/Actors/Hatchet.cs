using Codecool.DungeonCrawl.Logic.Map;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    class Hatchet : Actor
    {
        public Hatchet(Cell cell) : base(cell, TileSet.GetTile(TileType.Hatchet))
        {
            Health = 1;
            Attack = 0;
            Defense = 1000;
        }
        public override bool OnCollision(Actor other)
        {
            if (other is Player)
            {
                if(!other.hasHatchet);
                    this.Kill();
                    other.hasHatchet = true;
                    return true;
            }
            return false;
        }
    }
}