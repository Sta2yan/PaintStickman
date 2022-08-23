using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    private void Update()
    {
        if (_target != null && _target.position.x != transform.position.x)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_target.position.x, transform.position.y, transform.position.z), _speed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        if(target != null)
            _target = target;
    }

    private void OnValidate()
    {
        if (_speed < 0f)
            _speed = 0f;
    }
}
