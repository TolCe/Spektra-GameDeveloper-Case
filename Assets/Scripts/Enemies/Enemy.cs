using UnityEngine;

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

        CharacterManager.Instance.OnEnemyDeath(this);
    }
}
