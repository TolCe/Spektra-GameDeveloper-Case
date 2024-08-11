public class Enemy : Character
{
    public override void Initialize()
    {
        base.Initialize();

        gameObject.SetActive(true);
    }

    public override void Die()
    {
        base.Die();

        EnemyManager.Instance.OnEnemyDeath(this);
    }
}
