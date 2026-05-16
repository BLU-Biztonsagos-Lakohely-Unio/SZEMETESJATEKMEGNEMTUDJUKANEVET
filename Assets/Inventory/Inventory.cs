using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int Money;
    public ItemDataSO[] items = new ItemDataSO[10];
    //át kéne írni egy List-re mert az egyszerûbb

    public void AddItem(ItemDataSO targy)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = targy;
                Debug.Log("Added item to the inventory: " + targy);
                return;
            }
        }

    }
    public void RemoveItem(ItemDataSO targy)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == targy)
            {
                Debug.Log("Item Removed from inventory: " + targy);
                items[i] = null;
                return;
            }
        }
    }
    //teszteléshez
    public void AddMoney()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Added 1000 money to the inventory");
            Money += 1000;
        }
            
    }

}

