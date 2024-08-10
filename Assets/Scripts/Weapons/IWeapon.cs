public interface IWeapon
{
    public void Shoot(WeaponProperties weaponProperties);
    public Projectile CreateBullet();
}