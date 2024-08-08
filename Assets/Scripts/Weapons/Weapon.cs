using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponDataSO _weaponData;
    public WeaponDataSO WeaponData { get { return _weaponData; } }

    [SerializeField] private Transform _barrelPointTransform;
    public Transform BarrelPointTransform { get { return _barrelPointTransform; } }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
