using UnityEngine;

[CreateAssetMenu(fileName = "HealthData_", menuName = "Health Data")]
public class HealthDataSO : ScriptableObject
{
    [SerializeField] private float _health;
    public float Health { get { return _health; } }

    [SerializeField] private float _armour;
    public float Armour { get { return _armour; } }
}
