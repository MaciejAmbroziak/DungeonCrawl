using Codecool.DungeonCrawl.Logic.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    class DoorKey : Actor
    {
        public DoorKey(Cell cell) : base(cell, TileSet.GetTile(TileType.DoorKey))
        {
        }
        public override bool OnCollision(Actor other)
        {
            if (other is Player)
            {
                if (!other.hasDoorKey) ;
                this.Kill();
                other.hasDoorKey = true;
                return true;
            }
            return false;
        }
    }
}
