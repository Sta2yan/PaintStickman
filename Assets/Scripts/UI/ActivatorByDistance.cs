using System.Collections.Generic;
using UnityEngine;

public class ActivatorByDistance : MonoBehaviour
{
    [SerializeField] private List<GameObject> _disableObjects;
    [SerializeField] private Vector3 _size;

    private bool _isEnabled = true;

    private void OnEnable()
    {
        foreach (var gameObject in _disableObjects)
            gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_isEnabled == true)
            TryActivate();
    }

    private void TryActivate()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, _size, Quaternion.identity);

        foreach (var collider in colliders)
            if (collider.gameObject.TryGetComponent(out ArmyCollector army))
            {
                foreach (var gameObject in _disableObjects)
                    gameObject.SetActive(true);

                _isEnabled = false;
            }
    }
}
