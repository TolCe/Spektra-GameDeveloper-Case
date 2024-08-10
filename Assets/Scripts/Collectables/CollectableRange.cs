public class CollectableRange : Collectable, ICollectable
{
    public void SetUpgrade(WeaponProperties weaponProperties)
    {
        weaponProperties.Range *= CollectableData.BonusMultiplier;
    }
}
