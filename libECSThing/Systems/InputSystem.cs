using System;
using ECSThing.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace ECSThing.Systems;

public class InputSystem : EntityUpdateSystem
{
	public ComponentMapper<InputComponent> InputMapper => _inputMapper ?? throw new InvalidOperationException();
	public ComponentMapper<MovementComponent> MovementMapper => _movementMapper ?? throw new InvalidOperationException();

	private ComponentMapper<InputComponent>? _inputMapper;
	private ComponentMapper<MovementComponent>? _movementMapper;

	private KeyboardState _oldState;

	public InputSystem() : base(Aspect.All(typeof(InputComponent), typeof(MovementComponent))) { }

	public override void Initialize(IComponentMapperService mapperService)
	{
		_inputMapper    = mapperService.GetMapper<InputComponent>();
		_movementMapper = mapperService.GetMapper<MovementComponent>();
	}

	public override void Update(GameTime gameTime)
	{
		var keyboard = Keyboard.GetState();

		foreach (var entity in ActiveEntities)
		{
			var input = InputMapper.Get(entity);
			var movement = MovementMapper.Get(entity);

			foreach (var pair in input.MovementKeys)
			{
				if (IsKeyPress(ref keyboard, pair.Key))
				{
					movement.Direction += pair.Value;
					break;
				}
			}
		}

		_oldState = keyboard;
	}

	private bool IsKeyPress(ref KeyboardState keyboardState, Keys key) =>
		_oldState.IsKeyUp(key) && keyboardState.IsKeyDown(key);
}