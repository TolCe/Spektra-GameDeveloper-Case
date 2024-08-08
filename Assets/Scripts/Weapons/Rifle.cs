public class Rifle : Weapon, IWeapon
{
    public void Shoot()
    {
        Projectile projectile = CreateBullet();
        WeaponProperties weaponProperties = new WeaponProperties()
        {
            Damage = WeaponData.Damage,
            Range = WeaponData.Range,
            Speed = WeaponData.Speed,
        };
        projectile.SetTransform(transform.position, transform.eulerAngles);
        projectile.Initialize(weaponProperties);
    }

    public Projectile CreateBullet()
    {
        return ProjectileManager.Instance.GetProjectileByType(Enums.ProjectileTypes.Bullet);
    }
}
