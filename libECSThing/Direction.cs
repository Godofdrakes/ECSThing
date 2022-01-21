using Microsoft.Xna.Framework;

namespace ECSThing;

public static class Direction
{
	public static readonly Point North = new(0, -1);
	public static readonly Point South = new(0, 1);
	public static readonly Point East = new(-1, 0);
	public static readonly Point West = new(1, 0);

	public static readonly Point NorthEast = North + East;
	public static readonly Point NorthWest = North + West;
	public static readonly Point SouthEast = South + East;
	public static readonly Point SouthWest = South + West;
}
