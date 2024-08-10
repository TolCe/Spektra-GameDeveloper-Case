using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectilesData_", menuName = "Projectile/Rocket Data")]
public class RocketDataSO : ProjectileDataSO
{
    [SerializeField] private float _effectiveRadius;
    public float EffectiveRadius { get { return _effectiveRadius; } }
}
