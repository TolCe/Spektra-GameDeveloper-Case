using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    private float _currentCooldown;

    private Weapon _currentWeapon;

    [SerializeField] private List<Weapon> _weaponList;

    private List<Collectable> _upgradeList;

    public WeaponProperties _weaponProperties;
    public WeaponProperties WeaponProperties { get { return _weaponProperties; } }

    public void Initialize()
    {
        _upgradeList = new List<Collectable>();
        EquipWeapon(_weaponList[0].WeaponData.Type);
    }

    private void SetProperties()
    {
        _weaponProperties = new WeaponProperties(_currentWeapon.WeaponData.Damage, _currentWeapon.WeaponData.Range, _currentWeapon.WeaponData.Speed, _currentWeapon.WeaponData.ArmourPenetrationRatio);

        foreach (ICollectable collectable in _upgradeList)
        {
            collectable.SetUpgrade(_weaponProperties);
        }
    }

    private void Update()
    {
        if (_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;
        }
    }

    private void ResetCooldown()
    {
        _currentCooldown = 0;
    }

    public void Shoot()
    {
        if (_currentCooldown > 0)
        {
            return;
        }

        (_currentWeapon as IWeapon).Shoot(_weaponProperties);
        _currentCooldown = _currentWeapon.WeaponData.Cooldown;
    }

    public void EquipWeapon(Enums.WeaponTypes weaponType)
    {
        foreach (Weapon weapon in _weaponList)
        {
            weapon.Hide();
        }

        ResetCooldown();

        _currentWeapon = _weaponList.Find(x => x.WeaponData.Type == weaponType);
        _currentWeapon.Show();

        SetProperties();
    }

    public void GetUpgrade(ICollectable collectable)
    {
        if (!_upgradeList.Find(x => x.CollectableData.Type == (collectable as Collectable).CollectableData.Type))
        {
            _upgradeList.Add(collectable as Collectable);
            collectable.SetUpgrade(_weaponProperties);
        }
    }
}
