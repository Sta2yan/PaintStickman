using UnityEngine;

public class EnemyFollower : Follower
{
    private readonly float DistanceKillZ = -0.17f;

    protected override void Update()
    {
        base.Update();

        if (transform.position.z >= Target.position.z + DistanceKillZ)
        {
            Dead();

            if(Target.gameObject.TryGetComponent(out StickmanFollower stickmanFollower))
                stickmanFollower.StartDead();
        }
    }

    protected override Vector3 GetTargetPosition()
    {
        return new Vector3(Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime).x, transform.position.y, (Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime).z));
    }
}
