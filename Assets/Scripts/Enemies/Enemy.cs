using UnityEngine;

public class Enemy : Character
{
    public void Initialize(Vector3 position)
    {
        Initialize();

        MovementController.MoveTransform.position = position;
        gameObject.SetActive(true);
    }

    public override void Die()
    {
        base.Die();

        CharacterManager.Instance.OnEnemyDeath(this);
    }
}
