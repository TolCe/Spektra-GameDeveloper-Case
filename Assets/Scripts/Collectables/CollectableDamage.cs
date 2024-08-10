public class CollectableDamage : Collectable, ICollectable
{
    public void SetUpgrade(WeaponProperties weaponProperties)
    {
        weaponProperties.Damage *= CollectableData.BonusMultiplier;
    }
}
