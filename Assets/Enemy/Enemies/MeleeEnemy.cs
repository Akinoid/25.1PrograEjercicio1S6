using UnityEngine;

public class MeleeEnemy : EnemyBase
{
    protected override void Move()
    {
        if (player == null) return;
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
