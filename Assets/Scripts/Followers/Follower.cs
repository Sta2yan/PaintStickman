using UnityEngine;
using UnityEngine.Events;

public abstract class Follower : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    public float Speed => _speed;
    public Transform Target => _target;

    public event UnityAction<Follower> Die;

    protected virtual void Update()
    {
        if (_target != null)
            transform.position = GetTargetPosition();
    }

    public void SetTarget(Transform target)
    {
        if (target != null)
            _target = target;
    }

    protected void Dead()
    {
        Die?.Invoke(this);
        Destroy(gameObject);
    }

    protected abstract Vector3 GetTargetPosition();

    private void OnValidate()
    {
        if (_speed < 0f)
            _speed = 0f;
    }
}
