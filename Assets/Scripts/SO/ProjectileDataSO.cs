using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectilesData_", menuName = "Projectile/Projectiles Data")]
public class ProjectileDataSO : ScriptableObject
{
    public Enums.ProjectileTypes Type;
    public Projectile Prefab;
}
