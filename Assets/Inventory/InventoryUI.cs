using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;

    public Transform content;
    public GameObject itemPrefab;

    
    public TMP_Text InventoryWeightText;
    public TMP_Text moneyText;

    private void OnEnable()
    {
        // Ha már létezik az inventory, iratkozzunk fel
        if (Inventory.Instance != null)
        {
            SetupUI();
        }
    }

    private void Start()
    {
        // Biztonsági ellenõrzés, ha az Awake/OnEnable sorrend megtréfálna minket
        if (inventory == null && Inventory.Instance != null)
        {
            SetupUI();
        }
    }

    void SetupUI()
    {
        inventory = Inventory.Instance;
        inventory.onInventoryChanged -= RefreshUI; // Elõzzük meg a dupla feliratkozást
        inventory.onInventoryChanged += RefreshUI;
        RefreshUI();
    }

    private void OnDisable()
    {
        if (inventory != null)
        {
            inventory.onInventoryChanged -= RefreshUI;
        }
    }

    public void RefreshUI()
    {
        if (inventory == null) return;

        Debug.Log("Inventory UI frissítése folyamatban...");

        // Lista ürítése
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        // Új itemek létrehozása
        foreach (ItemDataSO item in inventory.items)
        {
            if (item == null) continue;

            GameObject obj = Instantiate(itemPrefab, content);
            InventoryItemUI ui = obj.GetComponent<InventoryItemUI>();
            if (ui != null)
            {
                ui.Setup(item);
            }
        }

        // JAVÍTÁS: A .text tulajdonságot állítjuk be a UI elemeken
        if (moneyText != null)
            moneyText.text = inventory.Money.ToString() + " $";

        if (InventoryWeightText != null)
            InventoryWeightText.text = $"Az inventory súlya: {InventoryWeight()} kg";

        Debug.Log($"UI frissítve. Súly: {InventoryWeight()}");
    }

    public float InventoryWeight()
    {
        float weight = 0f;
        if (inventory == null) return 0f;
        foreach (ItemDataSO item in inventory.items)
        {
            if (item != null) weight += item.Weight;
        }
        return weight;
    }
}