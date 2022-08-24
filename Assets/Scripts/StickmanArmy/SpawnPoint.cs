using System.Collections;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Position _position;

    private Follower _stickmanFollower;
    private WaitForSeconds _sleep = new WaitForSeconds(1.21f);

    public bool IsBusy => _stickmanFollower != null;
    public bool IsAttacked { get; private set; }
    public Follower Stickman => _stickmanFollower;
    public Position Position => _position;

    public void SetStickman(Follower stickman)
    {
        _stickmanFollower = stickman;
    }

    public Follower DeleteStickman()
    {
        Follower stickman = _stickmanFollower;
        _stickmanFollower = null;

        return stickman;
    }

    public void SetPosition(Position position)
    {
        _position = position;
    }

    public void StartAttack()
    {
        StartCoroutine(SetAttacked());
    }

    private IEnumerator SetAttacked()
    {
        IsAttacked = true;

        yield return _sleep;

        IsAttacked = false;
    }
}