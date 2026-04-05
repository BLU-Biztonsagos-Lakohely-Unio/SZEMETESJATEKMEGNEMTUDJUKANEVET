using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int Money;
    public List<ItemDataSO> items = new List<ItemDataSO>();
    //át kéne írni egy List-re mert az egyszerûbb

    

    public System.Action onInventoryChanged; //ui frissítése függvény

    public static Inventory Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PrintInventory();
        }
        
        //AddMoney();
    }
    public void AddItem(ItemDataSO targy)
    {
        items.Add(targy);
        Debug.Log("Added item to the inventory: " + targy);

        onInventoryChanged?.Invoke(); //ui frissítése
        Debug.Log("Event elindult");

        
       
        
    }
    public void RemoveItem(ItemDataSO targy)
    {
        //az elsõ megfelelõ itemet törli
        if (items.Contains(targy))
        {
            items.Remove(targy);
            Debug.Log("Item Removed: " + targy.ItemName);
            onInventoryChanged?.Invoke();
        }


    }
    //teszteléshez
    public void PrintInventory()
    {
        Debug.Log("Current Inventory:");
        foreach (var item in items)
        {
            if (item != null)
                Debug.Log(item.ItemName);
        }
    }
    public void AddMoney()
    {
        //nem mûködik, mert nem Update-ben van, de majd átírom
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Added 1000 money to the inventory");
            Money += 1000;
        }
            
    }

}

