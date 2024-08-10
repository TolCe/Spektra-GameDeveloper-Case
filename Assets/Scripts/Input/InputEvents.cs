using System;
using UnityEngine;

public static class InputEvents
{
    public static Action<Vector3> OnMovement;
    public static void CallMovement(Vector3 direction) { OnMovement?.Invoke(direction); }

    public static Action<Enums.WeaponTypes> OnWeaponChange;
    public static void CallWeaponChange(Enums.WeaponTypes weaponType) { OnWeaponChange?.Invoke(weaponType); }

    public static Action OnShoot;
    public static void CallShoot() { OnShoot?.Invoke(); }

    public static Action<Vector3> OnMouseMovement;
    public static void CallMouseMovement(Vector3 mousePosition) { OnMouseMovement?.Invoke(mousePosition); }
}
