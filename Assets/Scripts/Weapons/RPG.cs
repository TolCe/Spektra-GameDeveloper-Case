public class RPG : Weapon, IWeapon
{
    public void Shoot()
    {
        Projectile projectile = CreateBullet();
        projectile.SetTransform(transform.position, transform.eulerAngles);
        projectile.Initialize(SetWeaponProperties());
    }

    public Projectile CreateBullet()
    {
        return ProjectileManager.Instance.GetProjectileByType(Enums.ProjectileTypes.Rocket);
    }
}
