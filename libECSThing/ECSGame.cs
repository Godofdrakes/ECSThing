using System;
using ECSThing.Components;
using ECSThing.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Entities;

namespace ECSThing
{
	public class ECSGame : Game
	{
		public World World => _world ?? throw new InvalidOperationException();

		private World? _world;

		private GraphicsDeviceManager _graphics;

		public ECSGame()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_world = new WorldBuilder()
				.AddSystem(new InputSystem())
				.AddSystem(new MovementSystem())
				.AddSystem(new RenderSystem(GraphicsDevice))
				.Build();

			var factory = new EntityFactory(World);

			for (var yIndex = 0; yIndex < 5; yIndex++)
			{
				for (var xIndex = 0; xIndex < 5; xIndex++)
				{
					if (xIndex is 0 or 4 || yIndex is 0 or 4)
					{
						factory.AddWall(new Point(xIndex, yIndex));
					}
				}
			}
			
			factory.AddPlayer(new Point(1, 1));
			factory.AddBox(new Point(2, 2));
			factory.AddTarget(new Point(3, 3));

			Components.Add(World);

			// TODO: use this.Content to load your game content here
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
			    Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here

			base.Draw(gameTime);
		}
	}
}