using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    private float _cooldown;

    private Weapon _currentWeapon;

    [SerializeField] private List<Weapon> _weaponList;

    private void Start()
    {
        EquipWeapon(Enums.WeaponTypes.Pistol);
    }

    private void Update()
    {
        if (_cooldown > 0)
        {
            _cooldown -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (_cooldown > 0)
        {
            return;
        }

        (_currentWeapon as IWeapon).Shoot();
        _cooldown = _currentWeapon.WeaponData.Cooldown;
    }

    public void EquipWeapon(Enums.WeaponTypes weaponType)
    {
        foreach (Weapon weapon in _weaponList)
        {
            weapon.Hide();
        }

        _currentWeapon = _weaponList.Find(x => x.WeaponData.Type == weaponType);
        _currentWeapon.Show();
    }
}
