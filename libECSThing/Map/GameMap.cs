using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace ECSThing.Map;

public class GameMap
{
	public readonly Size Size;

	private readonly GameCell[,] _cells;

	public GameMap(Size size)
	{
		Size = size;
		_cells = new GameCell[size.Height, size.Width];
	}

	public GameCell this[Point point] => _cells[point.Y, point.X];
}
