using UnityEngine;

public class ShieldEnemy : EnemyBase
{
    [SerializeField] private float shieldInterval = 7f;
    private float shieldTimer;

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
