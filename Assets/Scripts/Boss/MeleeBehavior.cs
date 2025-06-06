using UnityEngine;

public class MeleeBehavior : IBossBehavior
{
    private float speed = 2f;

    public void Enter(Transform boss, Transform player) { }

    public void Execute(Transform boss, Transform player)
    {
        if (player == null) return;
        boss.position = Vector3.MoveTowards(boss.position, player.position, speed * Time.deltaTime);
    }

    public void Exit() { }
}
