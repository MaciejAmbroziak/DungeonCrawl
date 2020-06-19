using Codecool.DungeonCrawl.Logic.Map;

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
                this.Kill();
                other.DoorKey += 1;
                return true;
            }
            return false;
        }
    }
}
