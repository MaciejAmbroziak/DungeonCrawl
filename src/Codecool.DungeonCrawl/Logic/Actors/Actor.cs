using System.Collections.Generic;
using Perlin.Display;
using Perlin.Geom;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    ///     Actor is a base class for every entity in the dungeon.
    /// </summary>
    public abstract class Actor
    {
        public static readonly List<Actor> AllActors = new List<Actor>();

        // default ctor
        protected Actor(Cell cell, Rectangle tile)
        {
            AllActors.Add(this);

            Cell = cell;
            Cell.Actor = this;

            Sprite = new Sprite("tiles.png", false, tile);
            Sprite.ScaleX = Sprite.ScaleY = TileSet.Scale;

            Position = cell.Position;

            cell.Sprite.Parent.AddChild(Sprite);
        }

        public Cell Cell { get; private set; }

        public (float x, float y) Position
        {
            get => (Sprite.X / TileSet.Size / TileSet.Scale, Sprite.Y / TileSet.Size / TileSet.Scale);
            set
            {
                Sprite.X = value.x * TileSet.Size * TileSet.Scale;
                Sprite.Y = value.y * TileSet.Size * TileSet.Scale;
            }
        }

        public Sprite Sprite { get; set; }

        // dtor
        ~Actor()
        {
            AllActors.Remove(this);
        }

        /// <summary>
        ///     Gets called every frame
        /// </summary>
        public virtual void Update()
        {
        }

        /// <summary>
        ///     Assign this Actor to given cell
        /// </summary>
        /// <param name="target"></param>
        public void AssignCell(Cell target)
        {
            Cell.Actor = null;
            Cell = target;
            target.Actor = this;

            Position = target.Position;
        }
    }
}