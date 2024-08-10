using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private HealthDataSO _healthData;

    private HealthProperties _healthProperty;
    public HealthProperties HealthProperty { get { return _healthProperty; } }

    private Character _attachedCharacter;

    private void Awake()
    {
        _healthProperty = new HealthProperties();
    }

    public void Initialize(Character attachedCharacter)
    {
        _attachedCharacter = attachedCharacter;

        _healthProperty.Health = _healthData.Health;
        _healthProperty.Armour = _healthData.Armour;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void Die()
    {
        _attachedCharacter.Die();
    }

    public void GetShot(WeaponProperties weaponProperties)
    {
        float armourDamage = weaponProperties.Damage * (1 - weaponProperties.ArmourPenetrationRatio);
        float healthDamage = (weaponProperties.Damage - armourDamage) + Mathf.Clamp(armourDamage - _healthProperty.Armour, 0, Mathf.Infinity);

        ModifyArmour(-armourDamage);
        ModifyHealth(-healthDamage);

        if (_healthProperty.Health <= 0)
        {
            Die();
        }
    }

    public void ModifyHealth(float modifyAmount)
    {
        if (_healthProperty.Health <= 0)
        {
            return;
        }

        _healthProperty.Health += modifyAmount;
        _healthProperty.Health = Mathf.Clamp(_healthProperty.Health, 0, Mathf.Infinity);

        _attachedCharacter.HealthVisualizer.ModifyHealthBar(_healthProperty.Health / _healthData.Health);
    }

    public void ModifyArmour(float modifyAmount)
    {
        if (_healthProperty.Armour <= 0)
        {
            return;
        }

        _healthProperty.Armour += modifyAmount;
        _healthProperty.Armour = Mathf.Clamp(_healthProperty.Armour, 0, Mathf.Infinity);

        _attachedCharacter.HealthVisualizer.ModifyArmourBar(_healthProperty.Armour / _healthData.Armour);
    }

    public struct HealthProperties
    {
        public float Health;
        public float Armour;
    }
}
