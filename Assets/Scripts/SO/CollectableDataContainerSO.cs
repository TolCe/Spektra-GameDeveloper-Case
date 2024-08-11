using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectableDataContainer", menuName = "Collectable/Collectable Data Container")]
public class CollectableDataContainerSO : ScriptableObject
{
    [SerializeField] private List<CollectableDataSO> _collectableDataList;
    public List<CollectableDataSO> CollectableDataList {  get { return _collectableDataList; } }

    public CollectableDataSO GetDataByType(Enums.CollectableTypes type)
    {
        return _collectableDataList.Find(x => x.Type == type);
    }
}
