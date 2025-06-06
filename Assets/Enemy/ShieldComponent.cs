using UnityEngine;

public class ShieldComponent : MonoBehaviour
{
    private float duration = 4f;
    private float timer;
    private EnemyBase owner;

    public void Initialize(EnemyBase enemy)
    {
        owner = enemy;
        owner.IsShielded = true;
        timer = duration;        
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            owner.IsShielded = false;
            Destroy(this);
        }
    }
}
