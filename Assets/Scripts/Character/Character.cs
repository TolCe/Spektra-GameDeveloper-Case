using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private MovementController _movementController;
    public MovementController MovementController { get { return _movementController; } }

    [SerializeField] private HealthController _healthController;
    public HealthController HealthController { get { return _healthController; } }

    [SerializeField] private HealthVisualizer _healthVisualizer;
    public HealthVisualizer HealthVisualizer { get { return _healthVisualizer; } }

    [SerializeField] private ShootController _shootController;
    public ShootController ShootController { get { return _shootController; } }

    public virtual void Initialize()
    {
        _healthController.Initialize(this);
        _healthVisualizer.Initialize(this);
        _shootController.Initialize();
        _movementController.Initialize(this);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetPosition(Vector3 position)
    {
        MovementController.MoveTransform.position = position;
    }

    public void GetHit(WeaponProperties weaponProperties)
    {
        _healthController.GetHit(weaponProperties);
    }

    public virtual void Die()
    {
        _movementController.Stop();
    }
}
