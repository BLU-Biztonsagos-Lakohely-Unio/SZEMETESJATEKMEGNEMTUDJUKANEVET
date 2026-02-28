using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    
    
    public string ItemName;
    [TextArea] public string Description;
    public int BaseValue;
    public float Weight;
    public float WidthX;
    public float WidthZ;
    public float Height;
    public bool CanBePickedUp;
    public bool CanBeSold;
}
