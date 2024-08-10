using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileDataContainer", menuName = "Projectile/Projectile Data Container")]
public class ProjectileDataContainerSO : ScriptableObject
{
    [SerializeField] private List<ProjectileDataSO> _projectileDataList;

    public ProjectileDataSO GetDataByType(Enums.ProjectileTypes type)
    {
        return _projectileDataList.Find(x => x.Type == type);
    }
}
