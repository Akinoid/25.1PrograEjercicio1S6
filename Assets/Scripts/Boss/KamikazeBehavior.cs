using UnityEngine;

public class KamikazeBehavior : IBossBehavior
{
    private float speed = 3f;
    private float explosionDistance = 1.5f;
    private int damage = 40;
    private Transform boss;

    public void Enter(Transform boss, Transform player)
    {
        this.boss = boss;
    }

    public void Execute(Transform boss, Transform player)
    {
        if (player == null) return;
        boss.position = Vector3.MoveTowards(boss.position, player.position, speed * Time.deltaTime);
        if (Vector3.Distance(boss.position, player.position) < explosionDistance)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(damage);
            Debug.Log("Boss Kamikaze explota!");
            GameObject.Destroy(boss.gameObject);
        }
    }

    public void Exit() { }
}
