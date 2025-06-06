using UnityEngine;
using Game.Combat;

public class PlayerBullet : MonoBehaviour
{
    public float damage = 10f;
    public float lifeTime = 3f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyBase owner = other.GetComponent<EnemyBase>();
        if (other.CompareTag("Enemy")&& owner.IsShielded==false)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }

            Destroy(gameObject);            
        }
        else if(other.CompareTag("Boss"))
        {
            BossEnemy damageboss = other.GetComponent<BossEnemy>();

            damageboss.TakeDamage(damage);
            
        }
        
    }
}
