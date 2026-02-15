using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool isInventoryOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && isInventoryOpen)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            isInventoryOpen = false;
        }

        else if (Input.GetKeyDown("e") && !isInventoryOpen)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            isInventoryOpen = true;
        }
    }
}
