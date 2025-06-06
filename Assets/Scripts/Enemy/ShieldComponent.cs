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
        Debug.Log("tiene escudo");
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Debug.Log("pierde el escudo");
            owner.IsShielded = false;
            Destroy(this);
        }
    }
}
