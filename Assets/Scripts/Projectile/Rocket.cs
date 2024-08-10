using UnityEngine;

public class Rocket : Projectile, IProjectile
{
    public void Hit(HealthController healthController)
    {
        healthController?.GetShot(WeaponProperties);

        Despawn();
    }
}
