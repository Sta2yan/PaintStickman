using UnityEngine;

public class Tutorial : DisableTrigger
{
    [SerializeField] private DisableTrigger _disableTrigger;

    private void OnEnable()
    {
        _disableTrigger.Disabled += OnActive;
    }

    private void OnDisable()
    {
        _disableTrigger.Disabled -= OnActive;
    }

    private void OnActive()
    {
        Active();
    }
}
