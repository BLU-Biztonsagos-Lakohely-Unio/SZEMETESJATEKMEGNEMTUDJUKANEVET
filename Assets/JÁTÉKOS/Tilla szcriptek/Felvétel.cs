using Unity.VisualScripting;
using UnityEngine;

public class Felvétel : MonoBehaviour, IInteractable
{
    public Inventory inventory;
    public ItemData itemPrefab;
    void Start()
    {
        inventory = Inventory.Instance;
        itemPrefab = transform.GetComponent<ItemData>();
    }

    public void Interact()
    {
        
        Debug.Log("Felvetted: " + gameObject.name);
        inventory.AddItem(itemPrefab.Data);
        Destroy(gameObject);
    }
    
    public string InteractMessage => $"Press E to interact with {gameObject.name}";
}
