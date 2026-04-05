using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    public Image itemIcon;
    public TMP_Text itemNameText;
    public TMP_Text itemDescriptionText;
    public TMP_Text itemWeightText;
    
    public void Setup(ItemDataSO item)
    {
        Debug.Log($"Setting up inventory item UI for: {item.ItemName}");
        //itemIcon.sprite = null; //ha lesz képe a tárgynak, akkor ide kell majd beállítani
        itemNameText.text = item.ItemName;
        //itemDescriptionText.text = item.Description;
        itemWeightText.text = $"{item.Weight}kg"; 
    }
}
