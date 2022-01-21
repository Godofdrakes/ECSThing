using System.Drawing;
using Size = MonoGame.Extended.Size;

namespace ECSThing;

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