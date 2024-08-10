using UnityEngine;

public class CollectableArmourPiercing : Collectable, ICollectable
{
    public void SetUpgrade(WeaponProperties weaponProperties)
    {
        weaponProperties.ArmourPenetrationRatio *= CollectableData.BonusMultiplier;
        weaponProperties.ArmourPenetrationRatio = Mathf.Clamp(weaponProperties.ArmourPenetrationRatio, 0f, 100f);
    }
}
