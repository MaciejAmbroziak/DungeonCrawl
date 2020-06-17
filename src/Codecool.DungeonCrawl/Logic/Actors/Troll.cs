using System;
using Codecool.DungeonCrawl.Logic.Interfaces;
using Codecool.DungeonCrawl.Logic.Map;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    ///     Alpha enemy
    /// </summary>
    public class Troll : Actor, IUpdatable
    {
        private static readonly Random _random = new Random();
        private float _timeLastMove;

        public Troll(Cell cell) : base(cell, TileSet.GetTile(TileType.Troll))
        {
            Program.AllUpdatables.Add(this);
            Health = 120;
            Attack = 60;
            Defense = 30;
        }

        ~Troll()
        {
            Program.AllUpdatables.Remove(this);
        }

        public void Update(float deltaTime)
        {
            _timeLastMove += deltaTime;

            if (_timeLastMove <= 0.6f)
                return;

            _timeLastMove = 0.0f;

            var moveX = _random.Next(-1, 2);
            var moveY = _random.Next(-1, 2);

            if (moveX == 0 && moveY == 0)
                return;

            var dir = (moveX, moveY).ToDirection();

            TryMove(dir);
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
            if (other.GetType().Name == "Player" || other.GetType().Name == "Skeleton")
            {
                other.Health -= this.Attack - other.Defense;
                if (other.Health <= 0)
                {
                    other.Destroy();
                    return true;
                }
            }

            return false;
        }
    }
}