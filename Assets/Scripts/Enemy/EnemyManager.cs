using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }
    private int enemiesKilled = 0;
    public int EnemiesKilled => enemiesKilled;

    private readonly List<EnemyBase> allEnemies = new();

    private void Awake()
    {
        Instance = this;
    }

    public void Register(EnemyBase enemy)
    {
        allEnemies.Add(enemy);
    }

    public void Unregister(EnemyBase enemy)
    {
        allEnemies.Remove(enemy);
        enemiesKilled++;
    }

    public List<EnemyBase> GetEnemiesForShield()
    {
        return allEnemies.FindAll(e => !(e is ShieldEnemy) && !e.IsShielded);
    }
}
