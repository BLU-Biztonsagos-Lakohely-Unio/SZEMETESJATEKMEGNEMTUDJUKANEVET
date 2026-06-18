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
        Debug.Log("elbasztam az eladás függvényt");
        return 0;
    }
}
