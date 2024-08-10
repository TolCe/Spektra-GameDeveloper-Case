using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectilesData_", menuName = "Projectile/Projectiles Data")]
public class ProjectileDataSO : ScriptableObject
{
    [SerializeField] private Enums.ProjectileTypes _type;
    public Enums.ProjectileTypes Type { get { return _type; } }

    [SerializeField] private Projectile _prefab;
    public Projectile Prefab { get { return _prefab; } }

    [SerializeField] private LayerMask _targetLayers;
    public LayerMask TargetLayers { get { return _targetLayers; } }
}
