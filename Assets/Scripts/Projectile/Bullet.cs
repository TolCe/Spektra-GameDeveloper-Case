using UnityEngine;

public class Bullet : Projectile, IProjectile
{
    public void Hit(HealthController healthController)
    {
        healthController?.GetShot(WeaponProperties);

        Despawn();
    }
}
