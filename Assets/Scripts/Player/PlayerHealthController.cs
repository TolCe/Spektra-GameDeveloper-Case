public class PlayerHealthController : HealthController
{
    public override void Die()
    {
        base.Die();

        PlayerEvents.CallPlayerDeath();
    }
}
