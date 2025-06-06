using UnityEngine;
using Game.Combat;

public class ShieldEnemy : EnemyBase, IDamageable
{
    [SerializeField] private float shieldInterval = 7f;
    private float shieldTimer;
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

    protected override void Update()
    {
        base.Update();
        shieldTimer += Time.deltaTime;
        if (shieldTimer >= shieldInterval)
        {
            shieldTimer = 0;
            ApplyShields();
        }
    }

    private void ApplyShields()
    {
        var targets = EnemyManager.Instance.GetEnemiesForShield();
        foreach (var target in targets)
        {
            target.gameObject.AddComponent<ShieldComponent>().Initialize(target);
        }
    }

    protected override void Move()
    {
        if (player == null) return;
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
