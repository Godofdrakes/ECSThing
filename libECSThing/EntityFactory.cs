using ECSThing.Components;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;

namespace ECSThing;

public class EntityFactory
{
	private readonly World _world;

	public EntityFactory(World world)
	{
		_world = world;
	}

	public void AddPlayer(Point point)
	{
		var entity = _world.CreateEntity();
		entity.Attach(new InputComponent());
		entity.Attach(new MovementComponent());
		entity.Attach(new PositionComponent() {Point = point});
		entity.Attach(new BoxComponent()
		{
			Color = Color.Green,
			Fill  = true,
			Scale = 48f
		});
	}

	public void AddWall(Point point)
	{
		var entity = _world.CreateEntity();
		entity.Attach(new PositionComponent() {Point = point});
		entity.Attach(new BoxComponent()
		{
			Color = Color.Black,
			Fill  = true,
			Scale = 64f
		});
	}

	public void AddBox(Point point)
	{
		var entity = _world.CreateEntity();
		entity.Attach(new MovementComponent());
		entity.Attach(new PositionComponent() {Point = point});
		entity.Attach(new BoxComponent()
		{
			Color = Color.Red,
			Fill  = true,
			Scale = 48f,
		});
	}

	public void AddTarget(Point point)
	{
		var entity = _world.CreateEntity();
		entity.Attach(new PositionComponent() {Point = point});
		entity.Attach(new BoxComponent()
		{
			Color = Color.Red,
			Fill  = false,
			Scale = 56f,
		});
	}
}