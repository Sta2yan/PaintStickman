using UnityEngine;

public class NavigationZone : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out EnemyMover enemy))
            enemy.SetTarget(_target);
    }
}
