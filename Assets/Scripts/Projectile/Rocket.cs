using UnityEngine;
using UnityEngine.AI;

public class Rocket : Projectile
{
    public RocketDataSO RocketData { get { return ProjectileData as RocketDataSO; } }

    public override void OnHit(Character character)
    {
        base.OnHit(character);

        ExplodeOnHit();
    }

    private void ExplodeOnHit()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, RocketData.EffectiveRadius, RocketData.TargetLayers);
        foreach (Collider collider in colliders)
        {
            collider.GetComponentInParent<Character>()?.GetHit(WeaponProperties);
        }
    }

    public override void OnRangeReached()
    {
        ExplodeOnHit();

        base.OnRangeReached();
    }
}
