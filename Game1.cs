using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Project;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        GameState.ChangeGameState(EState.Menu);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        // Escape pauses Game. If already paused: resume game
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            if(GameState.CurrentGameState != EState.Paused && GameState.CurrentGameState != EState.Menu)
            {
                GameState.ChangeGameState(EState.Paused);
            }
            else if(GameState.CurrentGameState == EState.Paused)
            {
                GameState.ChangeGameState(EState.Running);
            }
        }

        switch(GameState.CurrentGameState)
        {
            case EState.Menu:
                //TODO: Menu Logic
                break;
            case EState.Running:
                //TODO: Running Logic
                break;
            case EState.Paused:
                //TODO: Paused Logic
                break;
            case EState.Halted:
                //TODO: Halted Logic
                break;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        switch(GameState.CurrentGameState)
        {
            case EState.Menu:
                //TODO: Menu Drawing-Logic
                break;
            case EState.Running:
                //TODO: Running Drawing-Logic
                break;
            case EState.Paused:
                //TODO: Paused Drawing-Logic
                break;
            case EState.Halted:
                //TODO: Halted Drawing-Logic
                break;
        }

        base.Draw(gameTime);
    }
}
