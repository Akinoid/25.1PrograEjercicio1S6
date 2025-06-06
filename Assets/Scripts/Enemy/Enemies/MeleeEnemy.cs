using UnityEngine;
using Game.Combat;

public class MeleeEnemy : EnemyBase, IDamageable
{
    public float maxHealth = 30f;
    private float currentHealth;
    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected override void Move()
    {
        if (player == null) return;
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
