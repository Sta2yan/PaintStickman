using UnityEngine;

[RequireComponent(typeof(AllySpawner), typeof(SkinnedMeshColorChanger))]
public class AllyColorChanger : MonoBehaviour
{
    private AllySpawner _ally;
    private SkinnedMeshColorChanger _colorChanger;

    private void Awake()
    {
        _ally = GetComponent<AllySpawner>();
        _colorChanger = GetComponent<SkinnedMeshColorChanger>();
    }

    private void OnEnable()
    {
        _ally.Spawned += OnAllySpawned;
    }

    private void OnDisable()
    {
        _ally.Spawned -= OnAllySpawned;
    }

    private void OnAllySpawned(Follower stickman)
    {
        if (stickman.gameObject.TryGetComponent(out SkinnedMeshColorChanger colorChanger))
        {
            colorChanger.Set(_colorChanger.Current);
            _colorChanger.Changed += colorChanger.Set;
        }
    }
}
