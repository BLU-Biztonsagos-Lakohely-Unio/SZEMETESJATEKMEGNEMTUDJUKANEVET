using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using PS;
using UnityEditor.ShortcutManagement;

public class UpgradeUI : MonoBehaviour
{
    
    public string Name;
    public int cost;
    [TextArea] public string description;
    [Space(5)]
    [Tooltip("ezzel választod ki melyik stat változzon")]
    public StatType StatChange;
    [Space(10)]
    public float AmountToChange;
    
    
    void Start()
    {
       
    }

    public void Upgarde()
    {
        switch (StatChange)
        {
            case StatType.Gyorsasag:
                PALYERSTAT.gyorsasag += AmountToChange;
                Debug.Log("Gyorsaság növelve: " + AmountToChange);
                break;
            case StatType.MaxHP:
                PALYERSTAT.MaxHp += (int)AmountToChange;
                Debug.Log("Max HP növelve: " + AmountToChange);
                break;
            case StatType.MaxST:
                PALYERSTAT.MaxStamina += (int)AmountToChange;
                Debug.Log("Max ST növelve: " + AmountToChange);
                break;
            case StatType.SlotokSzáma:
                Debug.Log("Slotok száma nem implementált");
                break;
        }
    }

    public enum StatType
    {
        Gyorsasag,
        MaxHP,
        MaxST,
        SlotokSzáma
    }
}