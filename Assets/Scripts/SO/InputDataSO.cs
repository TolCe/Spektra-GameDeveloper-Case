using UnityEngine;

[CreateAssetMenu(fileName = "InputData", menuName = "Input Data")]
public class InputDataSO : ScriptableObject
{
    [SerializeField] private KeyCode _forwardKey;
    public KeyCode ForwardKey { get { return _forwardKey; } }

    [SerializeField] private KeyCode _backwardsKey;
    public KeyCode BackwardsKey { get { return _backwardsKey; } }

    [SerializeField] private KeyCode _rightKey;
    public KeyCode RightKey { get { return _rightKey; } }

    [SerializeField] private KeyCode _leftKey;
    public KeyCode LeftKey { get { return _leftKey; } }

    [SerializeField] private KeyCode _shootKey;
    public KeyCode ShootKey { get { return _shootKey; } }

    [SerializeField] private KeyCode _selectPistolKey;
    public KeyCode SelectPistolKey { get { return _selectPistolKey; } }

    [SerializeField] private KeyCode _selectRifleKey;
    public KeyCode SelectRifleKey { get { return _selectRifleKey; } }

    [SerializeField] private KeyCode _selectRPGKey;
    public KeyCode SelectRPGKey { get { return _selectRPGKey; } }
}
