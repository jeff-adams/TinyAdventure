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

    private const int gameWidth = 500;
    private const int gameHeight = 500;

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
        graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
        graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
        graphics.ApplyChanges();
        
        canvas = new Canvas(GraphicsDevice, gameWidth, gameHeight);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        canvas.Activate();

        //Draw all the game stuff
        GraphicsDevice.Clear(Color.SeaGreen);

        canvas.Draw(spriteBatch);
        base.Draw(gameTime);
    }

    private void UpdateCanvasRenderSize(object sender, EventArgs e)
    {
        canvas.UpdateRenderRectangle();
    }
}
