using System.Collections;
using UnityEngine;

public class EnemyMovementController : MovementController, IMovable, IRotatable
{
    private Vector3 _targetPos;

    private void Start()
    {
        GetRandomPosition();
        StartCoroutine(MoveRoutine());
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _targetPos) < 0.2f)
        {
            GetRandomPosition();
        }
    }

    private void GetRandomPosition()
    {
        _targetPos = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
    }

    private IEnumerator MoveRoutine()
    {
        Vector3 direction = Vector3.zero;
        while (gameObject.activeInHierarchy)
        {
            direction = _targetPos - transform.position;

            MoveInDirection(direction.normalized);

            yield return new WaitForFixedUpdate();
        }
    }

    public void MoveInDirection(Vector3 direction)
    {
        MoveTransform.Translate(MovementData.Speed * direction * Time.fixedDeltaTime);
        LookAt(MoveTransform.position + direction);
    }

    public void LookAt(Vector3 position)
    {
        position.y = RotateTransform.position.y;
        RotateTransform.LookAt(position);
    }
}
