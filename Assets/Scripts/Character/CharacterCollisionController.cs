using UnityEngine;

public class CharacterCollisionController : MonoBehaviour
{
    [SerializeField] private Character _character;

    private void OnTriggerEnter(Collider other)
    {
        ICollectable collectable = other.GetComponentInParent<ICollectable>();
        if (collectable != null)
        {
            _character.ShootController.GetUpgrade(collectable);
            CollectableManager.Instance.CollectCollectable(collectable as Collectable);
        }
    }
}
