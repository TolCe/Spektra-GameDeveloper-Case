using UnityEngine;

[CreateAssetMenu(fileName = "CameraData", menuName = "Camera Data")]
public class CameraDataSO : ScriptableObject
{
    [SerializeField] private float _followSpeed;
    public float FollowSpeed { get { return _followSpeed; } }
}
