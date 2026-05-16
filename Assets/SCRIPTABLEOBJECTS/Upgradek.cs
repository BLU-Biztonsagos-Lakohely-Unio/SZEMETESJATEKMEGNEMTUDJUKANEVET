using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;


[CreateAssetMenu(menuName = "Upgrades/UpgradeNode")]
public class Upgrade : ScriptableObject
{
    public string Name;
    public int cost;
    [TextArea] public string description;
    [Space(5)]
    [Tooltip("ezzel választod ki melyik stat változzon")]
    public StatType StatChange;
    [Space(10)]
    public float AmountToChange;
    public enum StatType
    {
        Gyorsasag,
        MaxHP,
        MaxST,
        SlotokSzáma
    }

}

