using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ProjectileCollisionDetection : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;

    private void OnTriggerEnter(Collider other)
    {
        if (_projectile.ProjectileData.TargetLayers == (_projectile.ProjectileData.TargetLayers | (1 << other.gameObject.layer)))
        {
            _projectile.OnHit(other.GetComponentInParent<Character>());
        }
    }
}
