using System;
using UnityEngine;
using UnityEngine.UI;

public class RespawnScreen : Screen
{
    [SerializeField] private Button _respawnButton;

    private void OnEnable()
    {
        PlayerEvents.OnPlayerDeath += OnPlayerDeath;
    }
    private void Start()
    {
        _respawnButton.onClick.AddListener(OnRespawnButtonClicked);

        Hide();
    }

    private void OnRespawnButtonClicked()
    {
        Hide();
        PlayerEvents.CallPlayerRespawn();
    }

    private void OnDisable()
    {
        PlayerEvents.OnPlayerDeath -= OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        Show();
    }
}
