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
                if (other.DoorKey > 0)
                {
                    this.Health -= (other.Attack) * 1500;
                    if (Health <= 0)
                    {
                        other.DoorKey -= 1;
                        this.Kill();
                        return true;
                    }
                }
                else
                {
                    this.Health -= other.Attack;
                    if (Health <= 0)
                    {
                        this.Kill();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
