using System;

public static class PlayerEvents
{
    public static Action<CollectableDataSO> OnGetUpgrade;
    public static void CallGetUpgrade(CollectableDataSO data) { OnGetUpgrade?.Invoke(data); }

    public static Action OnPlayerDeath;
    public static void CallPlayerDeath() { OnPlayerDeath?.Invoke(); }

    public static Action OnPlayerRespawn;
    public static void CallPlayerRespawn() { OnPlayerRespawn?.Invoke(); }
}
