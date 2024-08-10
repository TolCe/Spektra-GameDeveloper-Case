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
            InputEvents.CallMovement(Vector3.forward);
        }
        if (Input.GetKey(_inputData.BackwardsKey))
        {
            InputEvents.CallMovement(Vector3.back);
        }
        if (Input.GetKey(_inputData.RightKey))
        {
            InputEvents.CallMovement(Vector3.right);
        }
        if (Input.GetKey(_inputData.LeftKey))
        {
            InputEvents.CallMovement(Vector3.left);
        }

        if (Input.GetKey(_inputData.ShootKey))
        {
            InputEvents.CallShoot();
        }

        if (Input.GetKey(_inputData.SelectPistolKey))
        {
            InputEvents.CallWeaponChange(Enums.WeaponTypes.Pistol);
        }
        if (Input.GetKey(_inputData.SelectRifleKey))
        {
            InputEvents.CallWeaponChange(Enums.WeaponTypes.Rifle);
        }
        if (Input.GetKey(_inputData.SelectRPGKey))
        {
            InputEvents.CallWeaponChange(Enums.WeaponTypes.RPG);
        }

        GetMousePosition();
    }

    public void GetMousePosition()
    {
        InputEvents.CallMouseMovement(Input.mousePosition);
    }
}
