using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameLibrary.Graphics;

public static class Iso
{
    public const int TileWidth = 64;
    public const int TileHeight = 32;
    public const float HeightStep = 16f;

    public static Vector2 WorldToScreen(Vector2 world, float z = 0f)
    {
        float screenX = (world.X - world.Y) * (TileWidth / 2);
        float screenY = (world.X + world.Y) * (TileHeight / 2) - z * HeightStep;
        return new Vector2(screenX, screenY);
    }

    public static Vector2 ScreenToWorld(Vector2 screen)
    {
        float worldX = (screen.X / (TileWidth / 2) + screen.Y / (TileHeight / 2)) / 2;
        float worldY = (screen.Y / (TileHeight / 2) - screen.X / (TileWidth / 2)) / 2;
        return new Vector2(worldX, worldY);
    }
}
