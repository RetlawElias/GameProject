using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;

namespace Game_Project;

public class Game1 : Core
{
    public Game1() : base("Game Project", 1280, 720, false)
    {

    }

    private int[,] _map =
    {
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 1, 1, 0, 0 },
        { 0, 1, 1, 1, 1, 0 },
        { 0, 0, 1, 1, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
    };

    private Sprite _grassSlab;
    private Point _hoveredTile;

    private Vector2 _mousePos;
    private Camera2D _camera;

    public int SingleInputIterator = 0;

    private Vector2 _cameraTarget;


    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        GameState.ChangeGameState(EState.Running);

        base.Initialize();
    }

    protected override void LoadContent()
    {

        TextureAtlas sprites = TextureAtlas.FromFile(Content, "images/sprites.xml");

        _grassSlab = sprites.CreateSprite("grass-slab");
        _grassSlab.Origin = new Vector2(_grassSlab.Region.Width * 0.5f, 0);

        _cameraTarget = Iso.WorldToScreen(new Vector2(3, 2.5f));

        _camera = new Camera2D(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        _camera.Position = Iso.WorldToScreen(new Vector2(3, 2.5f));


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

                float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
                KeyboardState keyboard = Keyboard.GetState();

                float panSpeed = 300f;

                if (keyboard.IsKeyDown(Keys.W)) _cameraTarget.Y -= panSpeed * dt;
                if (keyboard.IsKeyDown(Keys.S)) _cameraTarget.Y += panSpeed * dt;
                if (keyboard.IsKeyDown(Keys.A)) _cameraTarget.X -= panSpeed * dt;
                if (keyboard.IsKeyDown(Keys.D)) _cameraTarget.X += panSpeed * dt;

                _camera.Follow(_cameraTarget, dt);

                _mousePos = _camera.ScreenToWorld(Mouse.GetState().Position.ToVector2());
                _mousePos = Iso.ScreenToWorld(_mousePos);
                _hoveredTile = new Point((int)MathF.Floor(_mousePos.X), (int)MathF.Floor(_mousePos.Y));

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

        switch (GameState.CurrentGameState)
        {
            case EState.Menu:
                //TODO: Menu Drawing-Logic
                break;
            case EState.Running:
                //TODO: Running Drawing-Logic

                SpriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: _camera.Transform);

                for (int row = 0; row < _map.GetLength(0); row++)
                {
                    for (int col = 0; col < _map.GetLength(1); col++)
                    {
                        if (_map[row, col] == 0)
                        {
                            Vector2 pos = Iso.WorldToScreen(new Vector2(col, row));
                            _grassSlab.Color = (col == _hoveredTile.X && row == _hoveredTile.Y) ? Color.Gray : Color.White;
                            _grassSlab.Draw(SpriteBatch, pos);
                            
                            
                        }
                    }
                }

                SpriteBatch.End();

                break;
            case EState.Paused:

                //TODO: Paused Drawing-Logic
                break;
            case EState.Halted:
                //TODO: Halted Drawing-Logic
                break;
        }
        
        Debug.WriteDebugInfo(
            SpriteBatch,
            "RenderFrame: " + Debug.RenderFrame +
            "\nUpdateFrame: " + Debug.UpdateFrame +
            "\nGameState: " + GameState.CurrentGameState.ToString() + 
            "\nTile: " + _hoveredTile
        );

        base.Draw(gameTime);
    }
}
