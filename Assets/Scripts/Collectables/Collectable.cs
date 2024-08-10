using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private CollectableDataSO _collectableData;
    public CollectableDataSO CollectableData { get { return _collectableData; } }

    public void Initialize()
    {
        gameObject.SetActive(true);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}
