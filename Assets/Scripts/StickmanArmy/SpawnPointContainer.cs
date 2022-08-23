using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPointContainer : MonoBehaviour
{
    private readonly float DistanceSpawnPointZ = -0.47f;

    [SerializeField] private SpawnPoint _template;
    [SerializeField] private SpawnPoint _first;

    private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();

    private void Awake()
    {
        _spawnPoints.Add(_first);
    }

    public SpawnPoint GetNonBusy()
    {
        SpawnPoint spawnPoint = _spawnPoints.FirstOrDefault(point => point.IsBusy == false);

        if (spawnPoint == null)
            spawnPoint = GetNew();

        return spawnPoint;
    }

    public SpawnPoint GetLastBusy()
    {
        return _spawnPoints.LastOrDefault(point => point.IsBusy == true && point.IsAttacked == false);
    }

    public SpawnPoint GetRandomBusy()
    {
        var spawnPoint = _spawnPoints.Where(point => point.IsBusy == true && point.IsAttacked == false);
        var listSpawnPoint = spawnPoint.ToList();

        if (listSpawnPoint.Count != 0)
            return listSpawnPoint[Random.Range(0, listSpawnPoint.Count - 1)];
        else
            return null;
    }

    public int GetAllBusy()
    {
        int busyPoints = 0;

        for (int i = 0; i < _spawnPoints.Count; i++)
            if (_spawnPoints[i].IsBusy)
                busyPoints++;

        return busyPoints;
    }

    public SpawnPoint GetRearranged(StickmanFollower deadStickman)
    {
        SpawnPoint nonBusyPoint = null;

        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            if (_spawnPoints[i].Stickman == deadStickman)
            {
                nonBusyPoint = _spawnPoints[i];
                break;
            }
        }

        SpawnPoint busyPoint = GetLastBusy();

        if (nonBusyPoint == null || busyPoint == null)
            return null;

        bool isFind = ContainsBusyPointAfterPoint(busyPoint, GetIndexPointInList(nonBusyPoint));

        if (isFind)
        {
            Follower stickman = busyPoint.DeleteStickman();
            nonBusyPoint.SetStickman(stickman);
            return nonBusyPoint;
        }
        else
        {
            return null;
        }
    }

    public int GetIndexPointInList(SpawnPoint point)
    {
        int index = 0;

        for (; index < _spawnPoints.Count; index++)
            if (_spawnPoints[index] == point)
                break;

        return index;
    }

    private SpawnPoint GetNew()
    {
        SpawnPoint newSpawnPoint;

        newSpawnPoint = Instantiate(_template, new Vector3(_spawnPoints[_spawnPoints.Count - 1].transform.position.x,
                                                                                                                     _spawnPoints[_spawnPoints.Count - 1].transform.position.y,
                                                                                                                     _spawnPoints[_spawnPoints.Count - 1].transform.position.z + DistanceSpawnPointZ),
                                                                                                                     Quaternion.identity, transform);

        if (_spawnPoints[_spawnPoints.Count - 1].Position == Position.Left)
            newSpawnPoint.SetPosition(Position.Right);
        else
            newSpawnPoint.SetPosition(Position.Left);

        _spawnPoints.Add(newSpawnPoint);

        return newSpawnPoint;
    }

    private bool ContainsBusyPointAfterPoint(SpawnPoint busyPoint, int indexPoint)
    {
        for (; indexPoint < _spawnPoints.Count; indexPoint++)
            if (_spawnPoints[indexPoint] == busyPoint)
                return true;

        return false;
    }
}