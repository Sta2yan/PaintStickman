using UnityEngine;

public class TimeDestroy : MonoBehaviour
{
    [SerializeField] private float _time;

    private float _currentTime = 0;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _time)
            Destroy(gameObject);
    }
}
