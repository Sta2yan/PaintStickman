using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SkinnedMeshColorChanger))]
public class ArmyCollector : MonoBehaviour
{
    private SkinnedMeshColorChanger _changer;

    public event UnityAction<ArmyRefill> AllyCollected;
    public event UnityAction<ArmyRefill> EnemyCollected;

    private void Awake()
    {
        _changer = GetComponent<SkinnedMeshColorChanger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ArmyRefill army))
        {
            if (_changer.Current == army.Color)
                AllyCollected?.Invoke(army);
            else
                EnemyCollected?.Invoke(army);
        }
    }
}
