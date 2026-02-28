using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public Sprite itemIcon;
    public GameObject itemPrefab;
}

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryPanel;
    private bool isInventoryOpen = false;

    public List<InventoryItem> inventoryItems = new List<InventoryItem>();

    public Transform itemContainer;
    public GameObject itemSlotPrefab;

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
        InventoryPanel.SetActive(isInventoryOpen);

        if (isInventoryOpen)
        {
            UpdateInventoryUI();
        }

        Time.timeScale = isInventoryOpen ? 0 : 1;
    }

    public void AddItem(string nameToAdd, Sprite icon = null, GameObject prefab = null)
    {
        InventoryItem existingItem = inventoryItems.FirstOrDefault(item => item.itemName == nameToAdd);

        if (existingItem != null)
        {
            Debug.Log("Item already in inventory: " + nameToAdd);
            return;
        }

        inventoryItems.Add(new InventoryItem
        {
            itemName = nameToAdd,
            itemIcon = icon,
            itemPrefab = prefab
        });

        Debug.Log("Added to inventory: " + nameToAdd);

        if (isInventoryOpen)
        {
            UpdateInventoryUI();
        }
    }

    // UpdateInventoryUI() módosított verziója jobb vizuális megjelenéssel
    void UpdateInventoryUI()
    {
        foreach (Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (InventoryItem item in inventoryItems)
        {
            GameObject itemSlot = Instantiate(itemSlotPrefab, itemContainer);

            // Item név beállítása
            Text itemText = itemSlot.GetComponentInChildren<Text>();
            if (itemText != null)
            {
                itemText.text = item.itemName;
            }

            // Item ikon beállítása
            Image[] images = itemSlot.GetComponentsInChildren<Image>();
            foreach (Image img in images)
            {
                if (img.gameObject.name == "ItemIcon" && item.itemIcon != null)
                {
                    img.sprite = item.itemIcon;
                    img.enabled = true;
                }
            }
        }
    }

    public void RemoveItem(string nameToRemove)
    {
        InventoryItem itemToRemove = inventoryItems.FirstOrDefault(item => item.itemName == nameToRemove);

        if (itemToRemove != null)
        {
            inventoryItems.Remove(itemToRemove);
            Debug.Log("Removed from inventory: " + nameToRemove);

            if (isInventoryOpen)
            {
                UpdateInventoryUI();
            }
        }
    }
}