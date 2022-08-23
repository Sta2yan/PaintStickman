using DG.Tweening;
using UnityEngine;

public class SpriteColorChanger : ColorChanger
{
    [SerializeField] private SpriteRenderer _sprite;

    protected override void ChangeColor(GameColor gameColor)
    {
        if (_sprite == null)
            return;

        _sprite.material.DOColor(GameMaterial.Get(gameColor).color, Time).SetEase(Ease.OutBack);
    }
}
