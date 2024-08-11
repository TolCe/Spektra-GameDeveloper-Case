using System;
using UnityEngine;

public class UpgradeScreen : Screen, IPoolable
{
    [SerializeField] private UpgradeUIItem _prefab;
    [SerializeField] private Transform _container;
    private ObjectPool<UpgradeUIItem> _pool;

    private void Awake()
    {
        CreatePool();
    }
    private void OnEnable()
    {
        PlayerEvents.OnGetUpgrade += OnGetUpgrade;
        PlayerEvents.OnPlayerDeath += OnPlayerDeath;
    }
    private void OnDisable()
    {
        PlayerEvents.OnGetUpgrade -= OnGetUpgrade;
        PlayerEvents.OnPlayerDeath -= OnPlayerDeath;
    }

    private void OnGetUpgrade(CollectableDataSO data)
    {
        GetPoolItem().Initialize(data.Type.ToString());
    }

    private void OnPlayerDeath()
    {
        HideAllItems();
    }

    private UpgradeUIItem GetPoolItem()
    {
        return _pool.Get();
    }

    public void CreatePool()
    {
        _pool = new ObjectPool<UpgradeUIItem>(_prefab, 5, _container);
    }

    public void HideItem<T>(T item)
    {
        UpgradeUIItem uiItem = item as UpgradeUIItem;
        _pool.Return(uiItem);
    }

    public void HideAllItems()
    {
        _pool.ReturnAll();
    }
}
