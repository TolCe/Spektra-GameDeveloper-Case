using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileManager : Singleton<ProjectileManager>
{
    [SerializeField] private ProjectileDataContainerSO _projectileDataContainer;

    [SerializeField] private Transform _projectileContainer;

    private Dictionary<Enums.ProjectileTypes, ObjectPool<Projectile>> _projectilePoolDictionary;

    protected override void Awake()
    {
        base.Awake();

        CreatePools();
    }

    private void CreatePools()
    {
        _projectilePoolDictionary = new Dictionary<Enums.ProjectileTypes, ObjectPool<Projectile>>();

        for (int i = 0; i < Enum.GetNames(typeof(Enums.ProjectileTypes)).Length; i++)
        {
            Enums.ProjectileTypes type = (Enums.ProjectileTypes)i;
            ObjectPool<Projectile> projectilePool = new ObjectPool<Projectile>(_projectileDataContainer.GetProjectileDataByType(type).Prefab, 20, _projectileContainer);
            _projectilePoolDictionary.Add(type, projectilePool);
        }
    }

    public Projectile GetProjectileByType(Enums.ProjectileTypes type)
    {
        return _projectilePoolDictionary[type].Get();
    }

    public void HideItem(Projectile projectile)
    {
        _projectilePoolDictionary[projectile.ProjectileData.Type].Return(projectile);
    }

    public void HideAllItems()
    {
        List<ObjectPool<Projectile>> projectilePoolList = _projectilePoolDictionary.Values.ToList();
        foreach (ObjectPool<Projectile> projectilePool in projectilePoolList)
        {
            projectilePool.ReturnAll();
        }
    }
}
