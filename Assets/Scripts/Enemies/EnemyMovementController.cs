using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MovementController, IRotatable
{
    private Enemy _enemy;

    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private FieldOfView _fov;

    [SerializeField] private float _range;
    private Vector3 _destination;
    private bool _hasDestination;

    public override void Initialize(Character enemy)
    {
        base.Initialize(enemy);

        _enemy = enemy as Enemy;

        _navMeshAgent.speed = MovementData.Speed;
    }

    private void Update()
    {
        if (CanMove)
        {
            if (_fov.VisibleTargets.Count > 0)
            {
                LookAt(_fov.VisibleTargets[0].GetPosition());
                FollowTarget();

                _enemy.ShootController.Shoot();
            }
            else
            {
                LookAt(_navMeshAgent.destination);

                if (!_hasDestination)
                {
                    GoRandomPosition();
                }
                else
                {
                    if (Vector3.Distance(MoveTransform.position, _destination) < 2)
                    {
                        _hasDestination = false;
                    }
                }
            }
        }

        AnimationController.ModifyFloat("Vertical", Mathf.Clamp(_navMeshAgent.speed, 0f, 1f));
    }

    public override void Stop()
    {
        base.Stop();

        _navMeshAgent.isStopped = true;
    }

    private void GoRandomPosition()
    {
        _hasDestination = true;
        _destination = GetRandomPoint(Vector3.zero, _range);
        _navMeshAgent.SetDestination(_destination);
        _navMeshAgent.stoppingDistance = 0;
    }

    private void FollowTarget()
    {
        _hasDestination = false;
        _navMeshAgent.SetDestination(_fov.VisibleTargets[0].GetPosition());
        _navMeshAgent.stoppingDistance = 6;
    }

    private Vector3 GetRandomPoint(Vector3 center, float maxDistance)
    {
        return NavmeshControl.GetRandomPoint(center, maxDistance, MoveTransform.position.y);
    }

    public void LookAt(Vector3 position)
    {
        position.y = RotateTransform.position.y;
        RotateTransform.LookAt(position);
    }
}
