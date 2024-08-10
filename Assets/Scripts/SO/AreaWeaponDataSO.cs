using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData_", menuName = "Weapon Data")]
public class AreaWeaponDataSO : WeaponDataSO
{
    [SerializeField] private float _hitRadius;
    public float HitRadius { get { return _hitRadius; } }
}
