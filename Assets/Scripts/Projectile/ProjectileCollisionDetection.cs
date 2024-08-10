using UnityEngine;

public class ProjectileCollisionDetection : MonoBehaviour
{
    private IProjectile _projectile;

    private void Awake()
    {
        _projectile = GetComponentInParent<IProjectile>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _projectile.Hit(other.GetComponentInParent<HealthController>());
    }
}
