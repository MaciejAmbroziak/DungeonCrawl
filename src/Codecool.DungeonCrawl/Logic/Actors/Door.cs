using Codecool.DungeonCrawl.Logic.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    class Door : Actor
    {

        public Door(Cell cell) : base(cell, TileSet.GetTile(TileType.Door))
        {
            Health = 1500;
        }

        public override bool OnCollision(Actor other)
        {
            if (other is Player)
            {
                if (other.hasDoorKey == false)
                {
                    this.Health -= other.Attack;
                    if (Health <= 0)
                    {
                        this.Destroy();
                        return true;
                    }
                }

                if (other.hasDoorKey)
                {
                    this.Health -= (other.Attack) * 1500;
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
