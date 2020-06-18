using Codecool.DungeonCrawl.Logic.Interfaces;
using Codecool.DungeonCrawl.Logic.Map;
using Perlin;
using Veldrid;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    ///     The game player
    /// </summary>
    public class Player : Actor, IUpdatable
    {
        public Player(Cell cell) : base(cell, TileSet.GetTile(TileType.Player))
        {
            Program.AllUpdatables.Add(this);
            Health = 100;
            Attack = 50;
            Defense = 20;
            DoorKey = 0;
        }

        ~Player()
        {
            Program.AllUpdatables.Remove(this);
        }
        
        public void Update(float deltaTime)
        {
            if (KeyboardInput.IsKeyPressedThisFrame(Key.Up))
            {
                TryMove(Direction.Up);
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Key.Down))
            {
                TryMove(Direction.Down);
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Key.Left))
            {
                TryMove(Direction.Left);
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Key.Right))
            {
                TryMove(Direction.Right);
            }
            
            if (KeyboardInput.IsKeyPressedThisFrame(Key.Escape))
            {
                Program.Restart();
            }
        }

        private void TryMove(Direction dir)
        {
            var targetCell = Cell.GetNeighbour(dir);
            var canPass = targetCell?.OnCollision(this) ?? false;

            if (canPass)
                AssignCell(targetCell);
        }

        public override bool OnCollision(Actor other)
        {
            if (other is Skeleton || other is Troll || other is Chicken || other is Egg)
            { 
                int damage = this.Attack - other.Defense;
                if (damage >= 0) other.Health -= damage;
                if (other.Health <= 0)
                {
                    other.Kill();
                    return true;
                }
            }
           
            return false;
        }

        protected override void OnDeath()
        {
            Program.Restart();
        }
    }
}