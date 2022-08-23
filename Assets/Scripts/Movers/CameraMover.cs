using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _finishPoint;
    [SerializeField] private float _speed;

    private Transform _target;

    private void Update()
    {
        if ( _target != null && transform.position != _target.position)
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    public void ToFinishPoint()
    {
        _target = _finishPoint;
    }

    private void OnValidate()
    {
        if (_speed < 0)
            _speed = 0;
    }
}
