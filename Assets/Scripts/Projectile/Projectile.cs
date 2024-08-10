using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileDataSO _projectileData;
    public ProjectileDataSO ProjectileData { get { return _projectileData; } }

    public WeaponProperties WeaponProperties { get; private set; }

    public void Initialize(WeaponProperties weaponProperties)
    {
        WeaponProperties = weaponProperties;

        gameObject.SetActive(true);

        Move();
    }

    public void SetTransform(Vector3 pos, Vector3 rot)
    {
        transform.position = pos;
        transform.eulerAngles = rot;
    }

    public virtual void Move()
    {
        StartCoroutine(MoveRoutine());
    }

    private IEnumerator MoveRoutine()
    {
        Vector3 initPos = transform.position;

        while (gameObject.activeInHierarchy)
        {
            transform.Translate(WeaponProperties.Speed * transform.forward * Time.fixedDeltaTime, Space.World);

            if (Vector3.Distance(initPos, transform.position) > WeaponProperties.Range)
            {
                OnRangeReached();
            }

            yield return new WaitForFixedUpdate();
        }
    }

    public virtual void OnHit(Character character)
    {

    }

    public virtual void OnRangeReached()
    {
        Despawn();
    }

    private void Despawn()
    {
        ProjectileManager.Instance.HideItem(this);
    }
}

public class WeaponProperties
{
    public float Damage;
    public float Range;
    public float Speed;
    public float ArmourPenetrationRatio;
}
