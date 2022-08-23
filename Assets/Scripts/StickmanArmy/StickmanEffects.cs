using UnityEngine;

[RequireComponent(typeof(Follower))]
public class StickmanEffects : MonoBehaviour
{
    private readonly Quaternion Rotation = Quaternion.Euler(0f, 180f, 0f);

    [SerializeField] private GameObject _templateBlot;

    private Follower _stickman;

    private void Awake()
    {
        _stickman = GetComponent<Follower>();
    }

    private void OnEnable()
    {
        _stickman.Die += OnDie;
    }

    private void OnDisable()
    {
        _stickman.Die -= OnDie;
    }

    private void OnDie(Follower follower)
    {
        SpriteColorChanger colorChanger = Instantiate(_templateBlot, transform.position, Rotation).GetComponentInChildren<SpriteColorChanger>();
        colorChanger.Set(follower.GetComponent<ColorChanger>().Current);
    }
}
