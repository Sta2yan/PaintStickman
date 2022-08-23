using UnityEngine;

public class ObjectColor : MonoBehaviour
{
    [SerializeField] private GameColor _color;

    public GameColor Color => _color;
}
