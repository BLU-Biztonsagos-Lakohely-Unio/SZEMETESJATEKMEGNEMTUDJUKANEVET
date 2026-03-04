using System;
using UnityEngine;

public class PALYERSTAT : MonoBehaviour
{
    int hp = 100;
    public int HP
    {
        get { return hp; }
        set { hp = Mathf.Clamp(value, 0, 100); OnHPC?.Invoke(hp); }
    }
    int stamina = 100;
    public int Stamina
    {
        get { return stamina; }
        set { stamina = Mathf.Clamp(value, 0, 100); OnSTDC?.Invoke(stamina); }
    }
    int MaxCarryWeight = 10;
    int level = 1;
    int hunger = 100;
    int thtirst = 100;
    public float gyorsasag;

    public event Action<int> OnHPC;
    public event Action<int> OnSTDC;

}
