using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private MovementDataSO _movementData;
    public MovementDataSO MovementData { get { return _movementData; } }

    [SerializeField] private Transform _moveTransform;
    public Transform MoveTransform { get { return _moveTransform; } }
    [SerializeField] private Transform _rotateTransform;
    public Transform RotateTransform { get { return _rotateTransform; } }

    public virtual void Stop()
    {

    }
}
