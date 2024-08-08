using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputDataSO _inputData;

    [SerializeField] private PlayerMovementController _playerMovementController;
    [SerializeField] private PlayerShootController _playerShootController;

    private void FixedUpdate()
    {
        if (Input.GetKey(_inputData.ForwardKey))
        {
            GetInput(Vector3.forward);
        }
        if (Input.GetKey(_inputData.BackwardsKey))
        {
            GetInput(Vector3.back);
        }
        if (Input.GetKey(_inputData.RightKey))
        {
            GetInput(Vector3.right);
        }
        if (Input.GetKey(_inputData.LeftKey))
        {
            GetInput(Vector3.left);
        }

        if (Input.GetKey(_inputData.ShootKey))
        {
            _playerShootController.Shoot();
        }

        if (Input.GetKey(_inputData.SelectPistolKey))
        {
            _playerShootController.EquipWeapon(Enums.WeaponTypes.Pistol);
        }
        if (Input.GetKey(_inputData.SelectRifleKey))
        {
            _playerShootController.EquipWeapon(Enums.WeaponTypes.Rifle);
        }
        if (Input.GetKey(_inputData.SelectRPGKey))
        {
            _playerShootController.EquipWeapon(Enums.WeaponTypes.RPG);
        }

        GetMousePosition();
    }

    public void GetInput(Vector3 direction)
    {
        _playerMovementController.MoveInDirection(direction);
    }

    public void GetMousePosition()
    {
        _playerMovementController.LookAt(Input.mousePosition);
    }
}
