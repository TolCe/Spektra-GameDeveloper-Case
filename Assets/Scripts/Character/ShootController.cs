using System;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    private float _cooldown;
    public float Cooldown { get { return _cooldown; } }

    private Weapon _currentWeapon;

    [SerializeField] private List<Weapon> _weaponList;

    private List<Collectable> _upgradeList;

    public WeaponProperties _weaponProperties;
    public WeaponProperties WeaponProperties { get { return _weaponProperties; } }

    public void Initialize()
    {
        _upgradeList = new List<Collectable>();
        EquipWeapon(Enums.WeaponTypes.Pistol);
    }

    private void SetProperties()
    {
        _weaponProperties = new WeaponProperties()
        {
            Damage = _currentWeapon.WeaponData.Damage,
            Range = _currentWeapon.WeaponData.Range,
            Speed = _currentWeapon.WeaponData.Speed,
            ArmourPenetrationRatio = _currentWeapon.WeaponData.ArmourPenetrationRatio,
        };

        foreach (ICollectable collectable in _upgradeList)
        {
            collectable.SetUpgrade(_weaponProperties);
        }
    }

    private void Update()
    {
        if (_cooldown > 0)
        {
            _cooldown -= Time.deltaTime;
        }
    }

    public void ResetCooldown()
    {
        _cooldown = 0;
    }

    public void Shoot()
    {
        if (_cooldown > 0)
        {
            return;
        }

        (_currentWeapon as IWeapon).Shoot(_weaponProperties);
        _cooldown = _currentWeapon.WeaponData.Cooldown;
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
