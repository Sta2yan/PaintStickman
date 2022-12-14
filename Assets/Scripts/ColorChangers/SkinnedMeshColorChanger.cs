using DG.Tweening;
using UnityEngine;

public class SkinnedMeshColorChanger : ColorChanger
{
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;

    protected override void ChangeColor(GameColor gameColor)
    {   
        if (_skinnedMeshRenderer == null)
            return;

        _skinnedMeshRenderer.material = GameMaterial.Get(gameColor);
        _skinnedMeshRenderer.material.color = GameMaterial.Get(GameColor.White).color;
        _skinnedMeshRenderer.material.DOColor(GameMaterial.Get(gameColor).color, Time).SetEase(Ease.Linear);
    }
}
