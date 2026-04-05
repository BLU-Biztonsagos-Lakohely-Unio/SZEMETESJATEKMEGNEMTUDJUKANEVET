using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject Inventory_Panel;
    private bool isInventoryOpen = false;

    void Start()
    {
        // alapból kikapcsolt panel
        Inventory_Panel.SetActive(false);

        // cursor lock
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (Inventory_Panel == null)
            Inventory_Panel = transform.Find("Inventory_Panel").gameObject;

        Inventory_Panel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
            
        }
    }

    void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        Inventory_Panel.SetActive(isInventoryOpen);

        // játék megállítása / folytatása
        Time.timeScale = isInventoryOpen ? 0f : 1f;

        // kurzor kezelése
        Cursor.visible = isInventoryOpen;
        Cursor.lockState = isInventoryOpen ? CursorLockMode.None : CursorLockMode.Locked;
    }

    

   
}