using System;

public class PlayerShootController : ShootController
{
    private void OnEnable()
    {
        InputEvents.OnShoot += OnShoot;
        InputEvents.OnWeaponChange += OnWeaponChange;
    }
    private void OnDisable()
    {
        InputEvents.OnShoot -= OnShoot;
        InputEvents.OnWeaponChange -= OnWeaponChange;
    }

    private void OnShoot()
    {
        Shoot();
    }

    private void OnWeaponChange(Enums.WeaponTypes weaponType)
    {
        EquipWeapon(weaponType);
    }
}
