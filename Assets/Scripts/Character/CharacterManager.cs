using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterManager : Singleton<CharacterManager>
{
    [SerializeField] private Player _player;

    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _enemyContainer;
    private ObjectPool<Enemy> _enemyPool;

    [SerializeField] private float _enemySpawnRange;

    protected override void Awake()
    {
        base.Awake();

        CreatePool();
    }
    private void Start()
    {
        SpawnEnemyOnRandomPoint();
    }

    private void CreatePool()
    {
        _enemyPool = new ObjectPool<Enemy>(_enemyPrefab, 10, _enemyContainer);
    }

    private Enemy GetNewEnemy()
    {
        return _enemyPool.Get();
    }

    private void ReturnEnemy(Enemy deadEnemy)
    {
        _enemyPool.Return(deadEnemy);
    }

    public void OnEnemyDeath(Enemy deadEnemy)
    {
        ReturnEnemy(deadEnemy);
        SpawnEnemyOnRandomPoint();
    }

    private void SpawnEnemyOnRandomPoint()
    {
        Vector3 _randomPos = Random.insideUnitSphere * _enemySpawnRange;
        _randomPos.y = transform.position.y;
        NavMeshHit _hit;

        if (NavMesh.SamplePosition(_randomPos, out _hit, _enemySpawnRange, NavMesh.AllAreas))
        {
            GetNewEnemy().Initialize(_hit.position);
        }
        else
        {
            SpawnEnemyOnRandomPoint();
        }
    }
}
