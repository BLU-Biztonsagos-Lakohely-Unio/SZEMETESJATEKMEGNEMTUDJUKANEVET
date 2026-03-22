using Unity.VisualScripting;
using UnityEngine;

public class SaleManager : MonoBehaviour, IInteractable
{

    public GameObject NPC;
    public Inventory inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string InteractMessage => $"Press E to sell your soul to {gameObject.name}";

    public void Interact()
    {
        //Debug.Log("Interacted with " + gameObject.name);
        Selling();

    }
    public int Selling()
    {
        int money = 0;
        foreach (var item in inventory.items)
        {
            //Debug.Log($"item: {item}, Type: {item.GetType()}");
            if (item != null)
            {
                if (item.CanBeSold)
                {
                    money += item.BaseValue;
                    Debug.Log($"Sold {item.ItemName} to {gameObject.name} for {item.BaseValue}");
                    inventory.RemoveItem(item);
                }
                else
                {
                    Debug.Log($"{item.ItemName} cannot be sold to {gameObject.name}");
                }
            }

        }
        inventory.Money += money;
        Debug.Log($"You sold items for a total of {money} money.");
        return money;
    }
}
