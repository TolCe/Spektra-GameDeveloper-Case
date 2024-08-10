using UnityEngine;

public class Bullet : Projectile
{
    public override void OnHit(Character character)
    {
        base.OnHit(character);

        character?.GetHit(WeaponProperties);

        OnRangeReached();
    }
}
