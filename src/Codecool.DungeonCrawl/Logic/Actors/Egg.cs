using Codecool.DungeonCrawl.Logic.Interfaces;
using Codecool.DungeonCrawl.Logic.Map;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Codecool.DungeonCrawl.Logic.Actors
{
	class Egg : Actor, IUpdatable
	{
		private float _timeFromSpawn;

		public Egg(Cell cell) :base(cell, TileSet.GetTile(TileType.Egg))
		{
			Program.AllUpdatables.Add(this);
			Health = 5;
			Attack = 0;
			Defense = 10;
		}

		~Egg()
		{
			Program.AllUpdatables.Remove(this);
		}

		public void Update(float deltaTime)
		{
			_timeFromSpawn += deltaTime;

			if (_timeFromSpawn > 10.00f)
			{
				Destroy();
				Program.AllUpdatables.Remove(this);
				Program.AllUpdatables.Add(item: new Chicken(Cell.GetNeighbour((-1, 0).ToDirection()), false));
			}
		}

		public override bool OnCollision(Actor other)
		{
			if (other is Player)
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
