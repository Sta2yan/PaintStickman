using UnityEngine;

public class ArmyRefill : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private GameColor _color;
    [SerializeField] private GameMaterial _gameMaterial;

    public int Count => _count;
    public GameColor Color => _color;

    private void Awake()
    {
        SetMaterial(_gameMaterial.Get(_color));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ArmyCollector armyCollector))
            Destroy(gameObject);
    }

    private void SetMaterial(Material newMaterial)
    {
        SkinnedMeshRenderer[] skinnedMeshRenderers = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();

        foreach (var skinnedMeshRenderer in skinnedMeshRenderers)
            skinnedMeshRenderer.material = newMaterial;
    }

    private void OnValidate()
    {
        if (_count < 0)
            _count = 0;
    }
}