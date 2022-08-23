using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisableTrigger : MonoBehaviour
{
    [SerializeField] private List<GameObject> _gameObjects;

    public event UnityAction Disabled;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ArmyCollector army))
        {
            for (int i = 0; i < _gameObjects.Count; i++)
                _gameObjects[i].SetActive(false);

            Disabled?.Invoke();
        }
    }

    protected void Active()
    {
        for (int i = 0; i < _gameObjects.Count; i++)
            _gameObjects[i].SetActive(true);
    }
}
