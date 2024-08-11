using UnityEngine;

public class Rocket : Projectile
{
    public RocketDataSO RocketData { get { return ProjectileData as RocketDataSO; } }

    public override void OnHit(Character character)
    {
        Explode();

        base.OnHit(character);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, RocketData.EffectiveRadius, RocketData.TargetLayers);
        foreach (Collider collider in colliders)
        {
            collider.GetComponentInParent<Character>()?.GetHit(WeaponProperties);
        }
    }

    public override void OnRangeReached()
    {
        Explode();

        base.OnRangeReached();
    }
}
