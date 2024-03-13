using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TinyAdventure;

public class Player
{
    private Texture2D texture;
    private bool isFacingLeft;

    public ITransform Transform { get; private set; }

    public Player(Texture2D texture)
    {
        this.texture = texture;
    }

    public void Move(Vector2 direction)
    {
        Transform.Move(direction);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        SpriteEffects spriteEffect = isFacingLeft ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
        spriteBatch.Draw(texture, Transform.Position, null, Color.White, 0f, Vector2.Zero, 1.0f, spriteEffect, 1.0f);
    }
}