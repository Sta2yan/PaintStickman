using UnityEngine;

public class BulletFollower : Follower
{
    private readonly float TimeToKill = 0.81f;

    protected override void Update()
    {
        base.Update();

        if (transform.position == Target.position)
        {
            Dead();

            if (Target.gameObject.TryGetComponent(out StickmanFollower stickmanFollower))
            {
                if (stickmanFollower.gameObject.TryGetComponent(out SkinnedMeshColorChanger colorChanger))
                    colorChanger.Set(gameObject.GetComponent<MeshColorChanger>().Current);
                
                stickmanFollower.StartDead(TimeToKill);
            }
       }
    }

    protected override Vector3 GetTargetPosition()
    {
        return Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
    }
}
