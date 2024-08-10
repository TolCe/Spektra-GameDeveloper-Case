using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData_", menuName = "Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    [SerializeField] private Enums.WeaponTypes _type;
    public Enums.WeaponTypes Type { get { return _type; } }

    [SerializeField] private float _cooldown;
    public float Cooldown { get { return _cooldown; } }

    [Range(0f, 1f)][SerializeField] private float _armourPenetrationRatio;
    public float ArmourPenetrationRatio { get { return _armourPenetrationRatio; } }

    [SerializeField] private float _damage;
    public float Damage { get { return _damage; } }

    [SerializeField] private float _range;
    public float Range { get { return _range; } }

    [SerializeField] private float _speed;
    public float Speed { get { return _speed; } }
}
