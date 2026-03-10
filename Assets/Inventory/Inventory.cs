using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemData[] items = new ItemData[10];

    public void additem(ItemData targy)
    {
        foreach(var item in items)
        {
            int i= 0;
            if (items[i] != null)
            {
                i++;
            }
            else
            {
                items[i] = targy;
                break;
            }
        }
        Debug.Log("Added item: " + targy.name);
    }
    
    

}
