using UnityEngine;
using System;

public abstract class EnemyBase : MonoBehaviour
{
    public static Action OnAnyEnemyKilled;

    [SerializeField] protected float speed = 3f;
    [SerializeField] protected int health = 10;

    protected Transform player;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyManager.Instance.Register(this);
    }

    protected virtual void Update()
    {
        Move();
    }

    protected abstract void Move();

    public virtual void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) Die();
    }

    protected virtual void Die()
    {
        OnAnyEnemyKilled?.Invoke();
        EnemyManager.Instance.Unregister(this);
        Destroy(gameObject);
    }

    public virtual bool IsShielded { get; set; } = false;

}
