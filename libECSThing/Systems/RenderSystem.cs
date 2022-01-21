using System;
using ECSThing.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace ECSThing.Systems;

public class RenderSystem : EntityDrawSystem
{
	public ComponentMapper<PositionComponent> PositionMapper => _positionMapper ?? throw new InvalidOperationException();
	public ComponentMapper<BoxComponent> BoxMapper => _boxMapper ?? throw new InvalidOperationException();

	private ComponentMapper<PositionComponent>? _positionMapper;
	private ComponentMapper<BoxComponent>? _boxMapper;

	private readonly GraphicsDevice _graphicsDevice;
	private readonly SpriteBatch _spriteBatch;

	private const float TILE_SCALE = 64f;

	public RenderSystem(GraphicsDevice graphicsDevice)
		: base(Aspect.All(typeof(BoxComponent), typeof(BoxComponent)))
	{
		_graphicsDevice = graphicsDevice;
		_spriteBatch = new SpriteBatch(graphicsDevice);
	}

	public override void Initialize(IComponentMapperService mapperService)
	{
		_positionMapper = mapperService.GetMapper<PositionComponent>();
		_boxMapper = mapperService.GetMapper<BoxComponent>();
	}

	public override void Draw(GameTime gameTime)
	{
		_graphicsDevice.Clear(Color.CornflowerBlue);
		
		_spriteBatch.Begin(samplerState: SamplerState.PointClamp);

		foreach (var entity in ActiveEntities)
		{
			var position = PositionMapper.Get(entity);
			var box = BoxMapper.Get(entity);

			var pos = new Point2(position.Point.X * TILE_SCALE, position.Point.Y * TILE_SCALE);
			var size = new Size2(box.Scale, box.Scale);
			var offset = new Vector2(TILE_SCALE - box.Scale, TILE_SCALE - box.Scale);
			var rect = new RectangleF(pos + offset, size - offset.ToSize());

			if (box.Fill)
				_spriteBatch.FillRectangle(rect, box.Color);
			else
				_spriteBatch.DrawRectangle(rect, box.Color, 2f);
		}
		
		_spriteBatch.End();
	}
}