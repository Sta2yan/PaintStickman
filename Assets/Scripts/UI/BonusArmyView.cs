using TMPro;
using UnityEngine;

[RequireComponent(typeof(ArmyRefill))]
public class BonusArmyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _countText;

    private ArmyRefill _armyRefill;

    private void Awake()
    {
        _armyRefill = GetComponent<ArmyRefill>();
    }

    private void OnEnable()
    {
        Set(_armyRefill.Count);
    }

    private void Set(int count)
    {
        _countText.text = count.ToString();
    }
}
