using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ECSThing.Components;

public class InputComponent
{
	public Dictionary<Keys, Point> MovementKeys { get; } = new()
	{
		{Keys.Up, Direction.North},
		{Keys.Down, Direction.South},
		{Keys.Left, Direction.East},
		{Keys.Right, Direction.West},
	};
}