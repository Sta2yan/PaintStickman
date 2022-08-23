using TMPro;
using UnityEngine;

[RequireComponent(typeof(AllySpawner))]
public class AllyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _countText;

    private AllySpawner _allySpawner;

    private void Awake()
    {
        _allySpawner = GetComponent<AllySpawner>();
    }

    private void OnEnable()
    {
        _allySpawner.CountChanged += Set;
    }

    private void OnDisable()
    {
        _allySpawner.CountChanged -= Set;
    }

    private void Set(int count)
    {
        _countText.text = count.ToString();
    }
}
