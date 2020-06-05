using Codecool.DungeonCrawl.Logic;
using Codecool.DungeonCrawl.Logic.Actors;
using Perlin;
using Perlin.Display;

namespace Codecool.DungeonCrawl
{
    /// <summary>
    ///     The main class and entry point.
    /// </summary>
    public class Program
    {
		/// <summary>
		///     Singleton instance of Program
		/// </summary>
        public static Program Instance;

        private Cell[,] _map;
        public Sprite MapContainer;

        private Program()
        {
            var (width, height) = MapLoader.GetMapDimensions();

            PerlinApp.Start(width * TileSet.Size * TileSet.Scale,
                height * TileSet.Size * TileSet.Scale,
                "Dungeon Crawl",
                OnStart);
        }

        /// <summary>
        ///     Entry point
        /// </summary>
        public static void Main()
        {
            Instance = new Program();
        }

        private void OnStart()
        {
            var stage = PerlinApp.Stage;
            stage.ScaleX = stage.ScaleY = TileSet.Scale;

            /*
            // health textField
            var healthTextField = new TextField(
                PerlinApp.FontRobotoMono.CreateFont(14),
                _map.Player.Health.ToString(),
                false);
            healthTextField.HorizontalAlign = HorizontalAlignment.Center;
            healthTextField.Width = 100;
            healthTextField.Height = 20;
            healthTextField.X = _map.Width * Tiles.TileWidth / 2 - 50;
            stage.AddChild(healthTextField);
            */

            stage.EnterFrameEvent += StageOnEnterFrameEvent;

            MapContainer = new Sprite();
            MapContainer.ScaleX = MapContainer.ScaleY;
            stage.AddChild(MapContainer);

            _map = MapLoader.LoadMap(MapContainer);
        }

        // this gets called every frame
        private void StageOnEnterFrameEvent(DisplayObject target, float elapsedtimesecs)
        {
            Actor.AllActors.ForEach(x => x.Update());
        }
    }
}