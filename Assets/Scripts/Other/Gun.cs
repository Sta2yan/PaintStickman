using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    [SerializeField] private int _shots;
    [SerializeField] private float _time;
    [SerializeField] private BulletFollower _bulletTemplate;
    [SerializeField] private SpawnPointContainer _target;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private SkinnedMeshColorChanger _colorChanger;
    [SerializeField] private Look _lookPoint;
    [SerializeField] private MeshRenderer _meshRenderer;

    private WaitForSeconds _sleepTime;
    private Coroutine _coroutine;
    private bool _isTake;

    public int Shots => _shots;

    public event UnityAction Taked;

    private void Awake()
    {
        _sleepTime = new WaitForSeconds(_time);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ArmyCollector army) && _isTake == false)
        {
            _isTake = true;
            _meshRenderer.gameObject.SetActive(false);
            _coroutine = StartCoroutine(StartShoot());
            Taked?.Invoke();
        }
    }

    private IEnumerator StartShoot()
    {
        for (int i = 0; i < _shots; i++)
        {
            Shoot();

            yield return _sleepTime;
        }
    }

    private void Shoot()
    {
        SpawnPoint spawnPoint = _target.GetRandomBusy();

        if (spawnPoint != null)
        {
            BulletFollower bullet = Instantiate(_bulletTemplate, _bulletSpawnPoint.transform.position, Quaternion.identity);
            bullet.SetTarget(spawnPoint.Stickman.transform);
            _lookPoint.SetTarget(spawnPoint.Stickman.transform);
            spawnPoint.StartAttack();

            if (bullet.gameObject.TryGetComponent(out MeshColorChanger colorChanger))
                colorChanger.Set(_colorChanger.Current);
        }
        else
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }
    }
}
