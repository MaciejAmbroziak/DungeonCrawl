using Codecool.DungeonCrawl.Logic.Map;
using Perlin.Geom;
using System;
using System.Collections.Generic;
using System.Text;
using Codecool.DungeonCrawl.Logic.Interfaces;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    class Sword : Actor
    {
        public Sword(Cell cell) : base(cell, TileSet.GetTile(TileType.Sword))
        {
            Attack = 30;
        }
        
        public override bool OnCollision(Actor other)
        {
            if (other is Player)
            {
                other.Attack += this.Attack;
                this.Destroy();
                return true;
            }
            return false;
        }
    }
}
