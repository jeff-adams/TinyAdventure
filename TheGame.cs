using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TinyAdventure;

public class TheGame : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private Canvas canvas;
    private Camera camera;

    private Texture2D chicken;
    private Player player;

    private const int gameWidth = 500;
    private const int gameHeight = 300;

    public TheGame()
    {
        graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        Window.AllowUserResizing = true;
        Window.IsBorderless = false;
        Window.Title = "Tiny Adventure";
        Window.ClientSizeChanged += UpdateCanvasRenderSize;
    }

    protected override void Initialize()
    {
        graphics.PreferredBackBufferWidth = gameWidth * 2;
        graphics.PreferredBackBufferHeight = gameHeight * 2;
        graphics.ApplyChanges();
        
        canvas = new Canvas(GraphicsDevice, gameWidth, gameHeight);
        camera = new Camera(Window, canvas);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        chicken = Content.Load<Texture2D>("Art/Actor/Animals/Chicken/SpriteSheetWhite");
        player = new Player(this);
        camera.Follow(player.Transform);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        player.Update(gameTime);
        camera.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        canvas.Activate();
        GraphicsDevice.Clear(Color.SeaGreen);
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, transformMatrix: camera.ViewMatrix);
        
        //Draw all the game stuff
        spriteBatch.Draw(chicken, new Vector2(25, 25), new Rectangle(0, 0, 16, 16), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
        spriteBatch.Draw(chicken, new Vector2(200, 100), new Rectangle(0, 0, 16, 16), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
        player.Draw(spriteBatch);
        
        spriteBatch.End();
        canvas.Draw(spriteBatch);
        base.Draw(gameTime);
    }

    private void UpdateCanvasRenderSize(object sender, EventArgs e) =>
        canvas.UpdateRenderRectangle();
}
