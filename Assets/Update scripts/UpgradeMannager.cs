using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using PS;
using UnityEditor.ShortcutManagement;
using Unity.VisualScripting;

public class UpgradeM : MonoBehaviour
{
    public Upgrade Up;
    string Name;
    int cost;
    string description;
    Upgrade.StatType StatChange;
    float AmountToChange;


    void Start()
    {
    Name = Up.Name;
    cost = Up.cost;
    description = Up.description;
    AmountToChange = Up.AmountToChange;
    StatChange = Up.StatChange;
    }

    public void Upgarde()
    {
        //if(cost < Inventory.pénz)
        switch (StatChange)
        {
            case Upgrade.StatType.Gyorsasag:
                Gyorsaság();
                break;
            case Upgrade.StatType.MaxHP:
                MaxHP();
                break;
            case Upgrade.StatType.MaxST:
                MaxSt();
                break;
            case Upgrade.StatType.SlotokSzáma:
                SlotokSzáma();
                break;
        }
    }

    public void Gyorsaság()
    {
        PALYERSTAT.MaxSeb += AmountToChange;
        Debug.Log("Gyorsaság növelve: " + AmountToChange);
    }
    public void MaxHP()
    {
        PALYERSTAT.MaxHp+= (int)AmountToChange;
        Debug.Log("Max HP növelve: " + AmountToChange);
    }
    public void SlotokSzáma()
    {
        Debug.Log("Slotok száma nem implementált");
    }
    public void MaxSt()
    {
        PALYERSTAT.MaxStamina += (int)AmountToChange;
        Debug.Log("Max ST növelve: " + AmountToChange);
    }

    
}