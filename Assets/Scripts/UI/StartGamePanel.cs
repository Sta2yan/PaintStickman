using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class StartGamePanel : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private TMP_Text _startText;
    [SerializeField] private UnityEvent _gameBeginStart;
    [SerializeField] private UnityEvent _gameStarted;

    private void OnEnable()
    {
        _gameBeginStart?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _startText.gameObject.SetActive(false);
        _gameStarted?.Invoke();
    }
}
