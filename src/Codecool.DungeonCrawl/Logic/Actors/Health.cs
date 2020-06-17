using System;
using Codecool.DungeonCrawl.Logic.Map;
using Perlin.Geom;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    class Health : Actor
    {
        public Health(Cell cell) : base(cell, TileSet.GetTile(TileType.Health))
        {
            Health = 30;
        }
        
        public override bool OnCollision(Actor other)
        {
            if (other is Player)
            {
                other.Health += this.Health;
                this.Destroy();
                return true;
            }
            return false;
        }
    }
}