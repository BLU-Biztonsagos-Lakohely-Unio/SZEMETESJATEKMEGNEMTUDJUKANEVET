using UnityEngine;

public class ItemData : MonoBehaviour
{
    public ItemDataSO Data;
    public int BaseValue;
    public string itemName,Description;
    public bool canBePickedUp, canBeSold;
    public float weight;
    void Awake()
    {
        itemName = Data.ItemName;
        BaseValue = Data.BaseValue;
        Description = Data.Description;
        canBePickedUp = Data.CanBePickedUp;
        canBeSold = Data.CanBeSold;
        weight = Data.Weight;
    }

    public void Interact(GameObject Player)
    {
        throw new System.NotImplementedException();
    }
    public override string ToString()
    {
        return $"Item Name: {name}\tDescription: {Description}\tCan be picked up: {canBePickedUp}\tCan be sold: {canBeSold}\tWeight: {weight}";
    }

}
