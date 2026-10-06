using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game_Project;
public static class Debug
{
    public static SpriteFont DebugFont;
    public static int UpdateFrame = 0;
    public static int RenderFrame = 0;

    public static void WriteDebugInfo(SpriteBatch _spriteBatch, string text)
    {
        _spriteBatch.Begin();
        _spriteBatch.DrawString(DebugFont, text, new Vector2(0,0), Color.White, 0, new Vector2(0,0),0.7f,SpriteEffects.None,0);
        _spriteBatch.End();
    }
}