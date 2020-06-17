using Codecool.DungeonCrawl.Logic.Map;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    class Shield : Actor
    {
        public Shield(Cell cell) : base(cell, TileSet.GetTile(TileType.Shield))
        {
            Attack = 30;
            Defense = 30;
        }
        
        public override bool OnCollision(Actor other)
        {
            if (other is Player)
            {
                other.Defense += this.Defense;
                this.Destroy();
                return true;
            }
            return false;
        }
    }
}