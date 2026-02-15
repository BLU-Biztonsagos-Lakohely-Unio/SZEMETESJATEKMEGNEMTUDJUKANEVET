using UnityEngine;
using Unity.Mathematics;
using System;

public abstract class Item : MonoBehaviour
{
    public ItemData Data;
    public int CurrentValue;
    public bool IsBroken;

    protected virtual void OnValidate()
    {
        if (Data.BaseValue < 0) Data.BaseValue = 0;
        if (Data.Weight < 0) Data.Weight = 0;
        
    }

    public virtual int GetSellPrice()
    {
        if (!Data.CanBeSold) return 0;
        return Data.BaseValue;
    }
    

}
