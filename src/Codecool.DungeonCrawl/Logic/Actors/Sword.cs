using Codecool.DungeonCrawl.Logic.Map;
using Perlin.Geom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    class Sword : Actor
    {
        public Sword(Cell cell, Rectangle tile) : base(cell, TileSet.GetTile(TileType.Sword))
        {
        }
    }
}
