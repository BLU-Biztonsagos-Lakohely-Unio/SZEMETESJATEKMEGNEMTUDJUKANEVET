using UnityEngine;

public class PickableItem : MonoBehaviour
{
    public ItemDataSO itemData;
    public string itemName = "Item";
    public Sprite itemIcon;

    public float pickupRadius = 2f;

    private Transform player;
    private bool playerInRange = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        playerInRange = distance <= pickupRadius;

        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            PickUp();
        }
    }

    void PickUp()
    {
        if (Inventory.Instance != null && itemData != null)
        {
            Inventory.Instance.AddItem(itemData);
            Debug.Log("Picked up: " + itemData.ItemName + " Súlya: " + itemData.Weight);
            //Destroy(gameObject);
        }
        else
        {
            Debug.LogError("Inventory nem található!");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}