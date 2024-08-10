using System;

public static class PlayerEvents
{
    public static Action OnPlayerDeath;
    public static void CallPlayerDeath() { OnPlayerDeath?.Invoke(); }

    public static Action OnPlayerRespawn;
    public static void CallPlayerRespawnd() { OnPlayerRespawn?.Invoke(); }
}
