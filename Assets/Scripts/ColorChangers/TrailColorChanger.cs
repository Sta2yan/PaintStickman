using UnityEngine;

[RequireComponent(typeof(ColorChanger))]
public class TrailColorChanger : MonoBehaviour
{
    [SerializeField] private TrailRenderer _trail;
    [SerializeField] private GameMaterial _material;

    private ColorChanger _colorChanger;

    private void Awake()
    {
        _colorChanger = GetComponent<ColorChanger>();
    }

    private void Start()
    {
        _trail.material = _material.Get(_colorChanger.Current);
    }
}
