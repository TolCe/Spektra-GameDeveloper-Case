using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private MovementController _movementController;
    public MovementController MovementController { get { return _movementController; } }

    [SerializeField] private HealthController _healthController;
    public HealthController HealthController { get { return _healthController; } }

    [SerializeField] private HealthVisualizer _healthVisualizer;
    public HealthVisualizer HealthVisualizer { get { return _healthVisualizer; } }

    public void Initialize()
    {
        _healthController.Initialize(this);
        _healthVisualizer.Initialize(this);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public virtual void Die()
    {
        _movementController.Stop();
    }
}
