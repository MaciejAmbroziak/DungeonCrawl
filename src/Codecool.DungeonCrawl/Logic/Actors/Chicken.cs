using Codecool.DungeonCrawl.Logic.Interfaces;
using Codecool.DungeonCrawl.Logic.Map;
using System;

namespace Codecool.DungeonCrawl.Logic.Actors
{
	class Chicken : Actor, IUpdatable
	{
        private static readonly Random _random = new Random();
        private float _timeLastMove;
        private float _timeLastEgg;

        private bool _breedable;


        public Chicken(Cell cell, bool breedable) : base(cell, TileSet.GetTile(TileType.Chicken))
		{
            _breedable = breedable;
            Program.AllUpdatables.Add(this);
            Health = 20;
            Attack = 10;
            Defense = 10;
        }

        ~Chicken()
		{
            Program.AllUpdatables.Remove(this);
		}

        public void Update(float deltaTime)
        {
            _timeLastMove += deltaTime;
            _timeLastEgg += deltaTime;

            if (_timeLastMove <= 0.69f)
                return;

            _timeLastMove = 0.0f;

            var moveX = _random.Next(-1, 2);
            var moveY = _random.Next(-1, 2);

            if (moveX == 0 && moveY == 0)
                return;

            var dir = (moveX, moveY).ToDirection();

            TryMove(dir);

            if (_timeLastEgg < 10.00f || _breedable == false)
                return;

            Program.AllUpdatables.Add(new Egg(Cell.GetNeighbour((1,0).ToDirection())));

            _timeLastEgg = 0.00f;
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
            if (!(other is Chicken))
            {
                other.Health -= this.Attack - other.Defense;
                if (other.Health <= 0)
                {
                    other.Kill();
                    return true;
                }
            }
            return false;
        }
    }
}
