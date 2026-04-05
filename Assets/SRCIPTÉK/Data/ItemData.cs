using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemDataSO : ScriptableObject
{   
    public string ItemName;
    [TextArea] public string Description;
    public int BaseValue;
    public bool CanBePickedUp;
    public bool CanBeSold;
    public float Weight;
}
