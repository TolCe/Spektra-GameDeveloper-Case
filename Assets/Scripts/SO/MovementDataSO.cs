using UnityEngine;

[CreateAssetMenu(fileName = "MovementData_", menuName = "Movement Data")]
public class MovementDataSO : ScriptableObject
{
    [SerializeField] private float _speed;
    public float Speed { get { return _speed; } }
}
