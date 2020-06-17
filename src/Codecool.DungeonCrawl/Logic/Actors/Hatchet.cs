using Codecool.DungeonCrawl.Logic.Map;
using Perlin.Geom;
using System;
using System.Collections.Generic;
using System.Text;
using Codecool.DungeonCrawl.Logic.Interfaces;

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