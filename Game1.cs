using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Project;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    
    public int SingleInputIterator = 0;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        GameState.ChangeGameState(EState.Running);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Debug.DebugFont = Content.Load<SpriteFont>("DebugFont");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        Debug.UpdateFrame++;

        // Escape pauses Game. If already paused: resume game
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) && SingleInputIterator == 0)
        {
            if(GameState.CurrentGameState != EState.Paused && GameState.CurrentGameState != EState.Menu)
            {
                GameState.ChangeGameState(EState.Paused);
            }
            else if(GameState.CurrentGameState == EState.Paused)
            {
                GameState.ChangeGameState(EState.Running);
            }

            SingleInputIterator++;
        }
        else if(SingleInputIterator > 0 && !Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            SingleInputIterator = 0;
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
        Debug.RenderFrame++;

        GraphicsDevice.Clear(Color.CornflowerBlue);


        Debug.WriteDebugInfo(
            _spriteBatch,
            "RenderFrame: " + Debug.RenderFrame +
            "\nUpdateFrame: " + Debug.UpdateFrame + 
            "\nGameState: " + GameState.CurrentGameState.ToString()
        );


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
