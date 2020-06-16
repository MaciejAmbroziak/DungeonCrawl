using Codecool.DungeonCrawl.Logic.Map;
using Perlin.Geom;
using System;
using System.Collections.Generic;
using System.Text;
using Codecool.DungeonCrawl.Logic.Interfaces;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    class Sword : Actor, IUpdatable
    {
        public Sword(Cell cell) : base(cell, TileSet.GetTile(TileType.Sword))
        {
            Program.AllUpdatables.Add(this);
            Attack = 30;
        }
        
        ~Sword()
        {
            Program.AllUpdatables.Remove(this);
        }

        public void Update(float deltaTime)
        {
        }

        public override bool OnCollision(Actor other)
        {
            if (other.GetType() == typeof(Player))
            {
                other.Attack += this.Attack;
                this.Destroy();
                return true;
            }
            return false;
        }
    }
}
