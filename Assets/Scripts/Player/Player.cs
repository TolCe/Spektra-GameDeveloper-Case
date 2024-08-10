using System;
using UnityEngine;

public class Player : Character
{
    private void OnEnable()
    {
        PlayerEvents.OnPlayerRespawn += OnPlayerRespawn;
    }
    private void Start()
    {
        Initialize();
    }
    private void OnDisable()
    {
        PlayerEvents.OnPlayerRespawn -= OnPlayerRespawn;
    }

    private void OnPlayerRespawn()
    {
        SetPosition(Vector3.zero);
        Initialize();
    }

    public override void Die()
    {
        base.Die();
    }
}
