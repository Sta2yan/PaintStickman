using TMPro;
using UnityEngine;

[RequireComponent(typeof(Gun))]
public class GunView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textCount;

    private Gun _gun;

    private void Awake()
    {
        _gun = GetComponent<Gun>();
    }

    private void OnEnable()
    {
        Set(_gun.Shots);
        _gun.Taked += Invisible;
    }

    private void OnDisable()
    {
        _gun.Taked -= Invisible;
    }

    private void Set(int count)
    {
        _textCount.text = count.ToString();
    }

    private void Invisible()
    {
        _textCount.GetComponentInParent<Canvas>().gameObject.SetActive(false);
    }
}
