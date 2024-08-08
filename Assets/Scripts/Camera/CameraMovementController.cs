using UnityEngine;

public class CameraMovementController : MonoBehaviour, IMovable
{
    [SerializeField] private CameraDataSO _cameraData;

    [SerializeField] private PlayerMovementController _playerMovementController;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _playerMovementController.transform.position;
    }

    private void FixedUpdate()
    {
        MoveInDirection((_playerMovementController.transform.position + _offset) - transform.position);
    }

    public void MoveInDirection(Vector3 direction)
    {
        transform.Translate(_cameraData.FollowSpeed * direction * Time.fixedDeltaTime);
    }
}
