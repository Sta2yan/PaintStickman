using UnityEngine;

public class Look : MonoBehaviour
{
    private readonly string Rotate = "Rotate";
    private readonly string Blend = "Blend";

    [SerializeField] private Animator _animator;

    private Transform _target;

    private void Update()
    {
        if (_target != null)
            transform.LookAt(_target);
    }

    public void SetTarget(Transform target)
    {
        if (target != null)
            _target = target;

        _animator.SetTrigger(Rotate);
        _animator.SetFloat(Blend, transform.rotation.eulerAngles.y);
    }
}