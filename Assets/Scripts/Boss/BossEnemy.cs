using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    private IBossBehavior currentBehavior;
    private Transform player;
    public float maxHealth = 300;
    [SerializeField] private float currentHealth;

    public void Initialize(IBossBehavior behavior, Transform player)
    {
        this.player = player;
        SetBehavior(behavior);
        currentHealth = maxHealth;
    }

    private void Update()
    {
        currentBehavior?.Execute(transform, player);
    }

    public void SetBehavior(IBossBehavior newBehavior)
    {
        currentBehavior?.Exit();
        currentBehavior = newBehavior;
        currentBehavior?.Enter(transform, player);
    }

    public void TakeDamage(float amount)
    {
        currentHealth-= amount;
        if (currentHealth <= 0) Die();
    }

    protected virtual void Die()
    {        
        Destroy(gameObject);
    }
}
