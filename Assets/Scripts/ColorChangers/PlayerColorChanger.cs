using UnityEngine;

public class PlayerColorChanger : SkinnedMeshColorChanger
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ObjectColor portal))
            Set(portal.Color);
    }
}
