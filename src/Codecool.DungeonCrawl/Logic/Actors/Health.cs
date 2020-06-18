using Codecool.DungeonCrawl.Logic.Map;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    class Health : Actor
    {
        public Health(Cell cell) : base(cell, TileSet.GetTile(TileType.Health))
        {
            Health = 30;
            Attack = 0;
            Defense = 1000;
        }
        
        public override bool OnCollision(Actor other)
        {
            if (other is Player)
            {
                other.Health += this.Health;
                this.Kill();
                return true;
            }
            return false;
        }
    }
}