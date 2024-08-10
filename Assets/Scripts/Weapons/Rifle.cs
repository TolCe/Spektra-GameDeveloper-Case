using System.Collections;
using UnityEngine;

public class Rifle : Weapon, IWeapon
{
    public void Shoot(WeaponProperties weaponProperties)
    {
        StartCoroutine(BurstShot(weaponProperties));
    }

    private IEnumerator BurstShot(WeaponProperties weaponProperties)
    {
        for (int i = 0; i < 3; i++)
        {
            Projectile projectile = CreateBullet();
            projectile.SetTransform(transform.position, transform.eulerAngles);
            projectile.Initialize(weaponProperties);

            yield return new WaitForFixedUpdate();
        }
    }

    public Projectile CreateBullet()
    {
        return ProjectileManager.Instance.GetProjectileByType(Enums.ProjectileTypes.Bullet);
    }
}
