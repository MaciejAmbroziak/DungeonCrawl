using System;
using Codecool.DungeonCrawl.Logic.Map;
using Perlin.Geom;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    class Health : Actor
    {
        public Health(Cell cell, Rectangle tile) : base(cell, TileSet.GetTile(TileType.Health))
        {
            Health = 30;
        }
        
        public override bool OnCollision(Actor other)
        {
            if (other.GetType() == typeof(Player))
            {
                other.Health += this.Health;
                this.Destroy();
                return true;
            }
            return false;
        }
    }
}