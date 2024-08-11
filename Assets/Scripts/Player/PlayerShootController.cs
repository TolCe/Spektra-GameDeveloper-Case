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

    public override void AddNewUpgrade(ICollectable collectable)
    {
        base.AddNewUpgrade(collectable);

        PlayerEvents.CallGetUpgrade((collectable as Collectable).CollectableData);
    }
}
