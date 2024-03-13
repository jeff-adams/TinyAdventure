using Microsoft.Xna.Framework;

namespace TinyAdventure;

public static class Extensions
{
    public static Vector2 ToVector2(this Point point) =>
        new Vector2(point.X, point.Y);
        
    public static Vector2 PositionToVector2(this Rectangle rect) =>
        new Vector2(rect.X, rect.Y);
}