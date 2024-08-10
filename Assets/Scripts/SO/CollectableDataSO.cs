using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectableData_", menuName = "Collectable/Collectable Data")]
public class CollectableDataSO : ScriptableObject
{
    [SerializeField] private Enums.CollectableTypes _type;
    public Enums.CollectableTypes Type { get { return _type; } }

    [SerializeField] private float _bonusMultiplier;
    public float BonusMultiplier { get { return _bonusMultiplier; } }

    [SerializeField] private Collectable _prefab;
    public Collectable Prefab { get { return _prefab; } }

    [SerializeField] private int _amountOnScene;
    public int AmountOnScene { get { return _amountOnScene; } }

    [SerializeField] private int _poolSize;
    public int PoolSize { get { return _poolSize; } }
}
