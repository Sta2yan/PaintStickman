using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorConfing", menuName = "ScriptableObject/ColorConfing", order = 52)]
public class GameMaterial : ScriptableObject
{
    [SerializeField] private Material _white;
    [SerializeField] private Material _yellow;
    [SerializeField] private Material _orange;
    [SerializeField] private Material _purple;
    [SerializeField] private Material _blue;
    [SerializeField] private Material _red;

    public Material Get(GameColor color)
    {
        Material material = null;

        switch (color)
        {
            case GameColor.White:
                material = _white;
                break;
            case GameColor.Yellow:
                material = _yellow;
                break;
            case GameColor.Orange:
                material = _orange;
                break;
            case GameColor.Purple:
                material = _purple;
                break;
            case GameColor.Blue:
                material = _blue;
                break;
            case GameColor.Red:
                material = _red;
                break;
        }

        if (material == null)
            throw new InvalidOperationException();

        return material;
    }
}