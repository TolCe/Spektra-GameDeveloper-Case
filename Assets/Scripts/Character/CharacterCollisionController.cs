using UnityEngine;

public class CharacterCollisionController : MonoBehaviour
{
    [SerializeField] private Character _character;

    private void OnTriggerEnter(Collider other)
    {
        ICollectable collectable = other.GetComponentInParent<ICollectable>();
        if (collectable != null)
        {
            CollectableManager.Instance.CollectCollectable(_character, collectable);
        }
    }
}
