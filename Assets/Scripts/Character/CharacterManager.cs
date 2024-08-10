using UnityEngine;

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
        Vector3 point = NavmeshControl.GetRandomPoint(Vector3.zero, _enemySpawnRange, 0);

        if (point.magnitude != 0)
        {
            Enemy enemy = GetNewEnemy();
            enemy.Initialize();
            enemy.SetPosition(point);
        }
        else
        {
            SpawnEnemyOnRandomPoint();
        }
    }
}
