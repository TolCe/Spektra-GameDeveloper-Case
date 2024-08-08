using UnityEngine;

public class PlayerMovementController : MovementController, IMovable, IRotatable
{
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
