using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileDataSO _projectileData;
    public ProjectileDataSO ProjectileData { get { return _projectileData; } }

    private WeaponProperties _weaponProperties;

    public void Initialize(WeaponProperties weaponProperties)
    {
        _weaponProperties = weaponProperties;

        gameObject.SetActive(true);

        Move();
    }

    public void SetTransform(Vector3 pos, Vector3 rot)
    {
        transform.position = pos;
        transform.eulerAngles = rot;
    }

    private void OnTriggerEnter(Collider other)
    {
        Hit(other.GetComponent<IAlive>());
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
            transform.Translate(_weaponProperties.Speed * transform.forward * Time.fixedDeltaTime, Space.World);

            if (Vector3.Distance(initPos, transform.position) > _weaponProperties.Range)
            {
                Despawn();
            }

            yield return new WaitForFixedUpdate();
        }
    }

    public virtual void Hit(IAlive alive)
    {
        alive?.ModifyHealth(-_weaponProperties.Damage);

        Despawn();
    }

    public void Despawn()
    {
        ProjectileManager.Instance.HideItem(this);
    }
}

public struct WeaponProperties
{
    public int Damage;
    public float Range;
    public float Speed;
}
