using UnityEngine;
using System.Collections.Generic; // Required for HashSet
using System.Linq;               // Required for FirstOrDefault

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public int quantity;
}

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool isInventoryOpen = false;

    // Use a List if you need to access items by index, 
    // or stick with HashSet if you're managing unique references.
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        InventoryMenu.SetActive(isInventoryOpen);

        // Pauses game when open, resumes when closed
        Time.timeScale = isInventoryOpen ? 0 : 1;
    }

    public void AddItem(string nameToAdd)
    {
        // Check if the item already exists in the list
        InventoryItem existingItem = inventoryItems.FirstOrDefault(i => i.itemName == nameToAdd);

        if (existingItem != null)
        {
            existingItem.quantity++;
        }
        else
        {
            // Add a brand new item if it wasn't found
            inventoryItems.Add(new InventoryItem { itemName = nameToAdd, quantity = 1 });
        }
    }

    // Check if an item exists and we have at least one
    public bool HasItem(string nameToCheck)
    {
        return inventoryItems.Any(i => i.itemName == nameToCheck && i.quantity > 0);
    }
}