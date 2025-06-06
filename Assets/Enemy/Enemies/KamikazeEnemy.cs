using UnityEngine;

public class KamikazeEnemy : EnemyBase
{
    [SerializeField] private float explosionRadius = 3f;
    [SerializeField] private int explosionDamage = 20;

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
        
        Debug.Log("Kamikaze explota!");
        Die();
    }
}
