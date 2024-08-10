using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MovementController, IRotatable
{
    private Vector3 _targetPos;

    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private FieldOfView _fov;

    public float range;
    private Vector3 _destination;
    private bool _hasDestination;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _navMeshAgent.speed = MovementData.Speed;
    }

    private void Update()
    {
        if (_fov.VisibleTargets.Count > 0)
        {
            LookAt(_fov.VisibleTargets[0].GetPosition());
            FollowTarget();
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

    public override void Stop()
    {
        base.Stop();

        _navMeshAgent.isStopped = true;
    }

    private void GoRandomPosition()
    {
        _hasDestination = true;
        _navMeshAgent.SetDestination(GetRandomPoint(Vector3.zero, range));
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
        Vector3 _randomPos = Random.insideUnitSphere * maxDistance + center;
        _randomPos.y = MoveTransform.position.y;
        NavMeshHit _hit;

        if (NavMesh.SamplePosition(_randomPos, out _hit, maxDistance, NavMesh.AllAreas))
        {
            _destination = _hit.position;
        }

        return _destination;
    }

    public void LookAt(Vector3 position)
    {
        position.y = RotateTransform.position.y;
        RotateTransform.LookAt(position);
    }
}
