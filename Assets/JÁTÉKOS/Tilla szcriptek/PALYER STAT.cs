using System;
using UnityEngine;
namespace PS
{
    public class PALYERSTAT : MonoBehaviour
    {
        string Name= "Player";
        int hp = 100;
        public static int MaxHp = 100;
        int stamina = 100;
        public static int MaxST = 100;
        int level = 1;
        int hunger = 100;
        int thtirst = 100;
        public static float gyorsasag = 0f;
        int MaxCarryWeight = 10;


        public int HP
        {
            get { return hp; }
            set { hp = Mathf.Clamp(value, 0, MaxHp); OnHPC?.Invoke(hp); }
        }
        
        
        public int Stamina
        {
            get { return stamina; }
            set { stamina = Mathf.Clamp(value, 0, MaxST); OnSTDC?.Invoke(stamina); }
        }


        public event Action<int> OnHPC;
        public event Action<int> OnSTDC;

    }
    
}