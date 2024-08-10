using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool CanMove { get; private set; }

    [SerializeField] private MovementDataSO _movementData;
    public MovementDataSO MovementData { get { return _movementData; } }

    [SerializeField] private Transform _moveTransform;
    public Transform MoveTransform { get { return _moveTransform; } }
    [SerializeField] private Transform _rotateTransform;
    public Transform RotateTransform { get { return _rotateTransform; } }

    [SerializeField] private CharacterAnimationController _animationController;
    public CharacterAnimationController AnimationController { get { return _animationController; } }

    public virtual void Initialize(Character character)
    {
        MakeMovable();
    }

    public void MakeMovable()
    {
        CanMove = true;
    }

    public virtual void Stop()
    {
        CanMove = false;
    }
}
