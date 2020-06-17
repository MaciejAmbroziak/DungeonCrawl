using Codecool.DungeonCrawl.Logic.Map;
using Perlin.Geom;
using System;
using System.Collections.Generic;
using System.Text;
using Codecool.DungeonCrawl.Logic.Interfaces;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    class Bush : Actor
    {
        public Bush(Cell cell) : base(cell, TileSet.GetTile(TileType.Bush))
        {
            Health = 1500;
        }
        
        public override bool OnCollision(Actor other)
        {
            if (other is Player)
            {
                if (other.hasHatchet == false)
                {
                    this.Health -= other.Attack;
                    if (Health <= 0)
                    {
                        this.Destroy();
                        return true;
                    }
                }

                if (other.hasHatchet)
                {
                    this.Health -= (other.Attack) * 4;
                    if (Health <= 0)
                    {
                        this.Destroy();
                        return true;
                    }
                }

            }
            return false;
        }
    }
}