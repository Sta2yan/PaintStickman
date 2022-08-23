using UnityEngine;
using UnityEngine.Events;

public abstract class ColorChanger : MonoBehaviour
{
    [SerializeField] private GameMaterial _gameMaterial;
    [SerializeField] private float _time;
    [SerializeField] private GameColor _current;

    public GameMaterial GameMaterial => _gameMaterial;
    public float Time => _time;
    public GameColor Current => _current;

    public event UnityAction<GameColor> Changed;

    private void Awake()
    {
        ChangeColor(_current);
    }

    public void Set(GameColor gameColor)
    {
        _current = gameColor;
        Changed?.Invoke(Current);
        ChangeColor(gameColor);
    }

    protected abstract void ChangeColor(GameColor gameColor);

    private void OnValidate()
    {
        if (_time < 0f)
            _time = 0f;
    }
}
