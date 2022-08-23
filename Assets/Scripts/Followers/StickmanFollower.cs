using UnityEngine;
using UnityEngine.Events;

public class StickmanFollower : Follower
{
    public event UnityAction<Follower> BeganDead;

    protected override Vector3 GetTargetPosition()
    {
        Vector3 target = new Vector3(Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime).x, transform.position.y, transform.position.z);
        
        return target;
    }

    public void StartDead(float time = 0f)
    {
        BeganDead?.Invoke(this);
        Invoke(nameof(Dead), time);
    }
}