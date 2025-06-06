using UnityEngine;

public interface IBossBehavior
{
    void Enter(Transform boss, Transform player);
    void Execute(Transform boss, Transform player);
    void Exit();
}
