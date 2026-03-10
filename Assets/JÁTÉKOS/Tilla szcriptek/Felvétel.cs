using Unity.VisualScripting;
using UnityEngine;

public class Felvétel : MonoBehaviour, IInteractable
{
    public Inventory inventory;
    public ItemData itemPrgmefab;
    void Start()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
        itemPrgmefab = transform.GetComponent<ItemData>();
    }

    public void Interact()
    {
        
        Debug.Log("Interacted with " + gameObject.name);
        inventory.additem(itemPrgmefab);
        Destroy(gameObject);
    }
    
    public string InteractMessage => $"Press E to interact with {gameObject.name}";
}
