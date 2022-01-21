using System;
using ECSThing.Components;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace ECSThing.Systems;

public class MovementSystem : EntityUpdateSystem
{
	public ComponentMapper<MovementComponent> MoveMapper => _moveMapper ?? throw new InvalidOperationException();
	public ComponentMapper<PositionComponent> PositionMapper => _positionMapper ?? throw new InvalidOperationException();

	private ComponentMapper<MovementComponent>? _moveMapper;
	private ComponentMapper<PositionComponent>? _positionMapper;

	public MovementSystem() : base(Aspect.All(typeof(MovementComponent), typeof(PositionComponent))) { }

	public override void Initialize(IComponentMapperService mapperService)
	{
		_moveMapper = mapperService.GetMapper<MovementComponent>();
		_positionMapper = mapperService.GetMapper<PositionComponent>();
	}

	public override void Update(GameTime gameTime)
	{
		foreach (var entity in ActiveEntities)
		{
			var movement = MoveMapper.Get(entity);
			var position = PositionMapper.Get(entity);

			position.Point += movement.Direction;
			movement.Direction = Point.Zero;
		}
	}
}