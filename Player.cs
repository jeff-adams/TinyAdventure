using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyAdventure;

public class Player
{
    private Texture2D texture;
    private int textureScale = 2;
    private int textureCellSize = 16;

    private float speed = 1.25f;
    private bool isMoving = false;

    public ITransform Transform { get; private set; }

    public Player(Game game)
    {
        this.texture = game.Content.Load<Texture2D>("Art/Actor/Characters/DarkNinja/SpriteSheet");
        float textureScaledHalf = textureCellSize * 0.5f * textureScale;
        Vector2 textureOrigin = new(textureScaledHalf, textureScaledHalf);
        Transform = new Transform(textureOrigin);
    }

    public void Update(GameTime gameTime)
    {
        KeyboardState keyState = Keyboard.GetState();
        if (!keyState.GetPressedKeys().Any()) return;

        if (keyState.IsKeyDown(Keys.Right))
        {
            Move(Vector2.UnitX);
            return;
        }
        if (keyState.IsKeyDown(Keys.Left))
        {
            Move(-Vector2.UnitX);
            return;
        }
        if (keyState.IsKeyDown(Keys.Up))
        {
            Move(-Vector2.UnitY);
            return;
        }
        if (keyState.IsKeyDown(Keys.Down))
        {
            Move(Vector2.UnitY);
            return;
        }

        isMoving = false;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, Transform.Position, new Rectangle(0, 0, textureCellSize, textureCellSize), Color.White, 0f, Vector2.Zero, 2.0f, SpriteEffects.None, 1.0f);
    }

    private void Move(Vector2 direction)
    {
        // Calculate new position
        // Check for collisions
        // Move player to new position
        Transform.Move(direction);
        isMoving = true;
    }

}