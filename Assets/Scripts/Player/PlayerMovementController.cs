using UnityEngine;

public class PlayerMovementController : MovementController, IMovable, IRotatable
{
    private void OnEnable()
    {
        InputEvents.OnMovement += OnMovement;
        InputEvents.OnMouseMovement += OnMouseMovement;
    }
    private void OnDisable()
    {
        InputEvents.OnMovement -= OnMovement;
        InputEvents.OnMouseMovement -= OnMouseMovement;
    }

    public override void Initialize(Character character)
    {
        base.Initialize(character);
    }

    private void OnMovement(Vector3 direction)
    {
        if (!CanMove)
        {
            return;
        }

        MoveInDirection(direction);
        SetAnimation(direction);
    }

    private void SetAnimation(Vector3 direction)
    {
        AnimationController.ModifyFloat("Vertical", direction.x * Mathf.Sin(RotateTransform.eulerAngles.y) + direction.z * Mathf.Cos(RotateTransform.eulerAngles.y));
        AnimationController.ModifyFloat("Horizontal", direction.x * Mathf.Cos(RotateTransform.eulerAngles.y) + direction.z * Mathf.Sin(RotateTransform.eulerAngles.y));
    }

    private void OnMouseMovement(Vector3 position)
    {
        if (!CanMove)
        {
            return;
        }

        LookAt(position);
    }

    public void MoveInDirection(Vector3 direction)
    {
        MoveTransform.Translate(MovementData.Speed * direction * Time.fixedDeltaTime);
    }

    public void LookAt(Vector3 position)
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = position - playerScreenPosition;
        RotateTransform.eulerAngles = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg * Vector3.up;
    }
}
