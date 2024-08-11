using UnityEngine;

public class Bullet : Projectile
{
    public override void OnHit(Character character)
    {
        character?.GetHit(WeaponProperties);

        base.OnHit(character);
    }
}
