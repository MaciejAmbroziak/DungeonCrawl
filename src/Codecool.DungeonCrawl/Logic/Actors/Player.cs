using Perlin;
using Veldrid;

namespace Codecool.DungeonCrawl.Logic.Actors
{
    /// <summary>
    ///     The game player
    /// </summary>
    public class Player : Actor
    {
        public Player(Cell cell) : base(cell, TileSet.PlayerTile)
        {
        }

        public override void Update()
        {
            // process inputs
            if (KeyboardInput.IsKeyPressedThisFrame(Key.Up))
            {
                // TODO
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Key.Down))
            {
                // TODO
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Key.Left))
            {
                // TODO
            }

            if (KeyboardInput.IsKeyPressedThisFrame(Key.Right))
            {
                // TODO
            }
        }
    }
}