using UnityEngine;

public class ShieldBehavior : IBossBehavior
{
    private float shieldInterval = 6f;
    private float shieldTimer = 0f;

    public void Enter(Transform boss, Transform player) { }

    public void Execute(Transform boss, Transform player)
    {
        shieldTimer += Time.deltaTime;
        if (shieldTimer >= shieldInterval)
        {
            shieldTimer = 0f;
            var targets = EnemyManager.Instance.GetEnemiesForShield();
            foreach (var target in targets)
            {
                target.gameObject.AddComponent<ShieldComponent>().Initialize(target);
            }
        }
    }

    public void Exit() { }
}
