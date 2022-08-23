using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationPlayer : MonoBehaviour
{
    private readonly string Run = "Run";

    [SerializeField] private GameObject _gunTemplate;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void StartRun()
    {
        _animator.SetTrigger(Run);
    }

    private void PutOnGun()
    {
        _gunTemplate.SetActive(true);
    }

    private void PutAwayGun()
    {
        _gunTemplate.SetActive(false);
    }
}
