using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private bool _isActive = true;

    private void Update()
    {
        if (_isActive == true)
            transform.Translate(new Vector3(0, 0, _speed * Time.deltaTime));
    }

    public void Play()
    {
        _isActive = true;
    }

    public void Stop()
    {
        _isActive = false;
    }
}
