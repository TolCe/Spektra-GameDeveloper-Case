using System.Collections;
using UnityEngine;

public class Rifle : Weapon, IWeapon
{
    public void Shoot()
    {
        StartCoroutine(BurstShot());
    }

    private IEnumerator BurstShot()
    {
        for (int i = 0; i < 3; i++)
        {
            Projectile projectile = CreateBullet();
            projectile.SetTransform(transform.position, transform.eulerAngles);
            projectile.Initialize(SetWeaponProperties());

            yield return new WaitForFixedUpdate();
        }
    }

    public Projectile CreateBullet()
    {
        return ProjectileManager.Instance.GetProjectileByType(Enums.ProjectileTypes.Bullet);
    }
}
