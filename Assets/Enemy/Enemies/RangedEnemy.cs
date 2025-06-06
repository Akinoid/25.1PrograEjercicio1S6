using UnityEngine;

public class RangedEnemy : EnemyBase
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 3f;
    private float fireTimer;

    protected override void Update()
    {
        base.Update();
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            fireTimer = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        if (player == null || bulletPrefab == null) return;
        Vector3 dir = (player.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<EnemyBullet>().SetDirection(dir);
    }

    protected override void Move() {  }
}
