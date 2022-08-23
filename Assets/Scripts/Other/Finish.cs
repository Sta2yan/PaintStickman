using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    [SerializeField] private UnityEvent _finishBegan;
    [SerializeField] private UnityEvent _finishEnded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMover player))
            _finishBegan?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMover player))
            _finishEnded?.Invoke();
    }
}
