using UnityEngine;
using Game.Combat;


public class KamikazeEnemy : EnemyBase, IDamageable
{
    [SerializeField] private float explosionRadius = 3f;
    [SerializeField] private int explosionDamage = 20;

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

        if (Vector3.Distance(transform.position, player.position) < 1.5f)
        {
            Explode();
        }
    }

    private void Explode()
    {
        PlayerHealth damage = player.GetComponent<PlayerHealth>();

        damage.TakeDamage(explosionDamage);
       
        Debug.Log("Kamikaze explota!");
        Die();
    }
}
