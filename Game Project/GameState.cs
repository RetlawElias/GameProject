public enum EState
{
    Menu,
    Running,
    Paused,
    Halted
}

public static class GameState
{
    public static EState CurrentGameState; // Global Reference for the current state of the Game

    public static void ChangeGameState(EState NewState)
    {
        CurrentGameState = NewState;
    }
}


