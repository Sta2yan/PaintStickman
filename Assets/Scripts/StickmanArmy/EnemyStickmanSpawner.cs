using System.Collections;
using UnityEngine;

public class EnemyStickmanSpawner : MonoBehaviour
{
    [SerializeField] private EnemyFollower _template;
    [SerializeField] private ArmyCollector _armyCollector;
    [SerializeField] private SpawnPointContainer _spawnPointContainer;
    [SerializeField] private float _time;

    private int _counter = 0;
    private GameColor _color;
    private WaitForSeconds _sleepTime;
    private Coroutine _coroutine;

    private void Awake()
    {
        _sleepTime = new WaitForSeconds(_time);
    }

    private void OnEnable()
    {
        _armyCollector.EnemyCollected += OnSpawned;
    }

    private void OnDisable()
    {
        _armyCollector.EnemyCollected -= OnSpawned;
    }

    private void OnSpawned(ArmyRefill army)
    {
        if(army == null)
            return;

        _counter = army.Count;
        _color = army.Color;

        _coroutine = StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        for (int i = 0; i < _counter; i++)
        {
            Spawn();

            yield return _sleepTime;
        }
    }

    private void Spawn()
    {
        SpawnPoint spawnPoint = _spawnPointContainer.GetLastBusy();

        if (spawnPoint != null)
        {
            EnemyFollower enemyFollower = Instantiate(_template, transform.position, Quaternion.identity);
            enemyFollower.SetTarget(spawnPoint.Stickman.transform);
            spawnPoint.DeleteStickman();
            spawnPoint.StartAttack();

            if (enemyFollower.gameObject.TryGetComponent(out SkinnedMeshColorChanger colorChanger))
                colorChanger.Set(_color);
        }
        else
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }
    }

    private void OnValidate()
    {
        if (_time < 0f)
            _time = 0f;
    }
}