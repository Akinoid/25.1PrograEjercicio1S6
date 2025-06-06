using UnityEngine;

public class RangedBehavior : IBossBehavior
{
    private GameObject bulletPrefab;
    private float fireRate = 2f;
    private float fireTimer = 0f;

    public RangedBehavior(GameObject bulletPrefab)
    {
        this.bulletPrefab = bulletPrefab;
    }

    public void Enter(Transform boss, Transform player) { }

    public void Execute(Transform boss, Transform player)
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            fireTimer = 0f;
            Vector3 dir = (player.position - boss.position).normalized;
            GameObject bullet = GameObject.Instantiate(bulletPrefab, boss.position, Quaternion.identity);
            bullet.GetComponent<EnemyBullet>().SetDirection(dir);
        }
    }

    public void Exit() { }
}
