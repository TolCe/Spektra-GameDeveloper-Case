using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectableManager : Singleton<CollectableManager>, IPoolable
{
    [SerializeField] private CollectableDataContainerSO _collectableDataContainer;

    [SerializeField] private Transform _collectableContainer;

    private Dictionary<Enums.CollectableTypes, ObjectPool<Collectable>> _collectablePoolDictionary;

    protected override void Awake()
    {
        base.Awake();

        CreatePool();
    }
    private void Start()
    {
        SpawnCollectables();
    }

    public void CreatePool()
    {
        _collectablePoolDictionary = new Dictionary<Enums.CollectableTypes, ObjectPool<Collectable>>();

        foreach (CollectableDataSO data in _collectableDataContainer.CollectableDataList)
        {
            Enums.CollectableTypes type = data.Type;
            ObjectPool<Collectable> pool = new ObjectPool<Collectable>(data.Prefab, data.PoolSize, _collectableContainer);
            _collectablePoolDictionary.Add(type, pool);
        }
    }

    public void HideAllItems()
    {
        List<ObjectPool<Collectable>> poolList = _collectablePoolDictionary.Values.ToList();
        foreach (ObjectPool<Collectable> pool in poolList)
        {
            pool.ReturnAll();
        }
    }

    public Collectable GetCollectableByType(Enums.CollectableTypes type)
    {
        return _collectablePoolDictionary[type].Get();
    }

    public void HideItem<T>(T item)
    {
        Collectable collectable = item as Collectable;
        _collectablePoolDictionary[collectable.CollectableData.Type].Return(collectable);
    }

    public void SpawnCollectables()
    {
        Vector3 randomPoint = NavmeshControl.GetRandomPoint(Vector3.zero, 100, 0);

        foreach (CollectableDataSO data in _collectableDataContainer.CollectableDataList)
        {
            for (int i = 0; i < data.AmountOnScene; i++)
            {
                Collectable collectable = _collectablePoolDictionary[data.Type].Get();
                collectable.Initialize();
                collectable.SetPosition(NavmeshControl.GetRandomPoint(Vector3.zero, 100, 0));
            }
        }
    }

    public void CollectCollectable(Character collectedCharacter, ICollectable collectable)
    {
        collectedCharacter.ShootController.GetUpgrade(collectable);
        HideItem(collectable as Collectable);
    }
}
