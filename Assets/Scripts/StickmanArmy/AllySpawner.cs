using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ArmyCollector))]
public class AllySpawner : MonoBehaviour
{
    [SerializeField] private StickmanFollower _stickmanFollowerTemplate;
    [SerializeField] private SpawnPointContainer _spawnPointContainer;
    [SerializeField] private Transform _targetLeft;
    [SerializeField] private Transform _targetRight;

    private ArmyCollector _collector;
    private int _count;

    public event UnityAction<Follower> Spawned;
    public event UnityAction<int> CountChanged;

    private void Awake()
    {
        _collector = GetComponent<ArmyCollector>();
    }

    private void OnEnable()
    {
        _collector.AllyCollected += OnCollected;
    }

    private void OnDisable()
    {
        _collector.AllyCollected -= OnCollected;
    }

    private void OnCollected(ArmyRefill army)
    {
        for (int i = 0; i < army.Count; i++)
            SpawnStickmanFollower();
    }

    private void SpawnStickmanFollower()
    {
        SpawnPoint spawnPoint = _spawnPointContainer.GetNonBusy();

        StickmanFollower stickmanFollower = Instantiate(_stickmanFollowerTemplate, new Vector3(transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), Quaternion.identity, spawnPoint.transform);
        spawnPoint.SetStickman(stickmanFollower);
        SetTarget(stickmanFollower, spawnPoint);

        Spawned?.Invoke(stickmanFollower);
        _count++;
         CountChanged?.Invoke(_count);

        stickmanFollower.Die += OnStickmanDie;
    }

    private void SetTarget(Follower stickman, SpawnPoint spawnPoint)
    {
        stickman.transform.position = new Vector3(transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);

        if (spawnPoint.Position == Position.Right)
            stickman.SetTarget(_targetRight);
        else
            stickman.SetTarget(_targetLeft);
    }

    private void OnStickmanDie(Follower follower)
    {
        if (follower is StickmanFollower stickman)
        {
            _count--;
            CountChanged?.Invoke(_count);

            SpawnPoint changedSpawnPoint = _spawnPointContainer.GetRearranged(stickman);
            
            if (changedSpawnPoint != null)
                SetTarget(changedSpawnPoint.Stickman, changedSpawnPoint);
        }
    }
}
