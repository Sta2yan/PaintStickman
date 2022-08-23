using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;
    private float _firstTouchPositionX;
    private bool _isActive = true;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (_isActive == true)
            Read();
    }

    public void DisableControl()
    {
        _isActive = false;
    }

    private void Read()
    {
        if (Input.GetMouseButton(0))
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                _firstTouchPositionX = touch.position.x;

            if (touch.phase == TouchPhase.Moved)
            {
                _mover.TryMoveHorizontalAxis(touch.position.x - _firstTouchPositionX);
                _firstTouchPositionX = touch.position.x;
            }
        }
    }
}
