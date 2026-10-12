using System;
using System.Dynamic;
using Microsoft.Xna.Framework;

namespace MonoGameLibrary.Graphics;

public class Camera2D
{
    public Vector2 Position
    {
        get;
        set;
    }

    public float Zoom
    {
        get;
        set;
    } = 1f;

    public int ViewportWidth
    {
        get;
    }
    public int ViewportHeight
    {
        get;
    }

    public float FollowSpeed
    {
        get;
        set;
    } = 8f;

    public void Follow(Vector2 target, float dt)
    {
        Position = Vector2.Lerp(Position, target, 1f - MathF.Exp(-FollowSpeed * dt));
    }

    public Matrix Transform => Matrix.CreateTranslation(-MathF.Round(Position.X), -MathF.Round(Position.Y), 0) * Matrix.CreateScale(Zoom, Zoom, 1) * Matrix.CreateTranslation(ViewportWidth * 0.5f, ViewportHeight * 0.5f, 0);

    public Vector2 ScreenToWorld(Vector2 screen)
    {
        return Vector2.Transform(screen, Matrix.Invert(Transform));
    }

    public Camera2D(int viewportWidth, int viewportHeight)
    {
        ViewportWidth = viewportWidth;
        ViewportHeight = viewportHeight;
    }
    
}