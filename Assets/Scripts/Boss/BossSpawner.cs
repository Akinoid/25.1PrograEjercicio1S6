using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private float timer = 0f;
    [SerializeField]private float spawnInterval = 60f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnBoss();
        }
    }

    private void SpawnBoss()
    {
        var point = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject bossGO = Instantiate(bossPrefab, point.position, Quaternion.identity);
        BossEnemy boss = bossGO.GetComponent<BossEnemy>();

        IBossBehavior behavior = GetRandomBehavior();
        boss.Initialize(behavior, GameObject.FindWithTag("Player").transform);

        Debug.Log("Boss ha aparecido con comportamiento: " + behavior.GetType().Name);
    }

    private IBossBehavior GetRandomBehavior()
    {
        int index = Random.Range(0, 4);
        return index switch
        {
            0 => new KamikazeBehavior(),
            1 => new RangedBehavior(bulletPrefab),
            2 => new ShieldBehavior(),
            3 => new MeleeBehavior(),
            _ => new MeleeBehavior()
        };
    }
}
