using DG.Tweening;
using UnityEngine;

public class MeshColorChanger : ColorChanger
{
    [SerializeField] private MeshRenderer _meshRenderer;

    protected override void ChangeColor(GameColor gameColor)
    {
        if (_meshRenderer == null)
            return;

        _meshRenderer.material.DOColor(GameMaterial.Get(gameColor).color, Time).SetEase(Ease.OutBack);
    }
}
