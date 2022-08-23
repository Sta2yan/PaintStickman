using TMPro;
using UnityEngine;
using DG.Tweening;

public class FinishPanel : MonoBehaviour
{
    private readonly float Scale = 1.5112f;
    private readonly float Time = 1f;

    [SerializeField] private TMP_Text _count;

    private void OnEnable()
    {
        transform.DOScale(Scale, Time);
    }

    private void SetCount(int count)
    {
        _count.text = count.ToString();
    }
}
