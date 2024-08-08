using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData_", menuName = "Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    [SerializeField] private Enums.WeaponTypes _type;
    public Enums.WeaponTypes Type { get { return _type; } }

    [SerializeField] private float _cooldown;
    public float Cooldown { get { return _cooldown; } }

    [SerializeField] private int _bulletsToCooldown;
    public int BulletsToCooldown { get { return _bulletsToCooldown; } }

    [SerializeField] private float _bulletInterval;
    public float BulletInterval { get { return _bulletInterval; } }

    [SerializeField] private int _damage;
    public int Damage { get { return _damage; } }

    [SerializeField] private float _range;
    public float Range { get { return _range; } }

    [SerializeField] private float _speed;
    public float Speed { get { return _speed; } }
}
