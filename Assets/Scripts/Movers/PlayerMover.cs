using UnityEngine;

 public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _minPositionX;

    private Vector3 _target;

    public void TryMoveHorizontalAxis(float direction)
    {
        if (direction < 0 && transform.position.x > _minPositionX)
            MoveHorizontalAxis(direction);

        if (direction > 0 && transform.position.x < _maxPositionX)
            MoveHorizontalAxis(direction);
    }

    private void MoveHorizontalAxis(float direction)
    {
        _target = Vector3.Lerp(transform.position, new Vector3(transform.position.x + direction, transform.position.y, transform.position.z), Time.deltaTime * _speed);

        if (_target.x > _maxPositionX)
            _target.x = _maxPositionX;

        if(_target.x < _minPositionX)
            _target.x = _minPositionX;

        transform.position = _target;
    }

    private void OnValidate()
    {
        if (_speed < 0f)
            _speed = 0f;
    }
}
