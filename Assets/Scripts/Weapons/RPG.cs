public class RPG : Weapon, IWeapon
{
    public void Shoot(WeaponProperties weaponProperties)
    {
        Projectile projectile = CreateBullet();
        projectile.SetTransform(transform.position, transform.eulerAngles);
        projectile.Initialize(weaponProperties);
    }
}
