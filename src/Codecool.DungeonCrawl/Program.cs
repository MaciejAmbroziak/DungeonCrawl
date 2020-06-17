﻿using System.Collections.Generic;
using System.Linq;
using Codecool.DungeonCrawl.Logic.Interfaces;
using Codecool.DungeonCrawl.Logic.Map;
using Perlin;
using Perlin.Display;

namespace Codecool.DungeonCrawl
{
    /// <summary>
    ///     The main class and entry point.
    /// </summary>
    public static class Program
    {
        public static GameMap Map { get; private set; }

        public static List<IUpdatable> AllUpdatables = new List<IUpdatable>();

        private static Sprite _mapContainer;

        /// <summary>
        ///     Entry point
        /// </summary>
        public static void Main()
        {
            var (width, height) = MapLoader.GetMapDimensions();

            PerlinApp.Start(width * TileSet.Size * TileSet.Scale,
                height * TileSet.Size * TileSet.Scale,
                "Dungeon Crawl",
                OnStart);
        }

        private static void OnStart()
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

            _mapContainer = new Sprite();
            _mapContainer.ScaleX = _mapContainer.ScaleY;
            stage.AddChild(_mapContainer);

            Map = MapLoader.LoadMap(_mapContainer);
        }

        /// <summary>
        ///     Updates every frame (Full VSync by default)
        /// </summary>
        /// <param name="target"></param>
        /// <param name="deltaTime"></param>
        private static void StageOnEnterFrameEvent(DisplayObject target, float deltaTime)
        {
			try
			{
				AllUpdatables.ForEach(x => x.Update(deltaTime));
			}
			catch (System.Exception)
			{
				System.Console.WriteLine("List change mid for loop");
			}
        }
    }
}