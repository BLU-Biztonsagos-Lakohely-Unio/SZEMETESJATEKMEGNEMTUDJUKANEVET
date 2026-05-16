using System;
using UnityEngine;

namespace PS
{
    /// <summary>
    /// A játékos összes alap statisztikáját tárolja és kezeli.
    /// Eseményeken keresztül értesíti a többi rendszert (UI, StaminaManagement stb.)
    /// </summary>
    public class PALYERSTAT : MonoBehaviour
    {
        [Header("Alap adatok")]
        public string playerName = "Player";
        public int level = 1;
        public int maxhp = MaxHp;
        public int maxstamina = MaxStamina;
        public int maxhunger = MaxHunger;
        public int maxthirst = MaxThirst;
        public float gg = MaxSeb;
        public void Update()
        {
            maxhp = MaxHp;
            maxstamina = MaxStamina;
            maxhunger = MaxHunger;
            maxthirst = MaxThirst;
            gg = gyorsasag;
        }
        [Header("statikok")]
        public static float MaxSeb= 10f;
        public static int MaxHp = 100;
        public static int MaxStamina = 100;
        public static int MaxHunger = 100;
        public static int MaxThirst = 100;


        /// <summary>
        /// Mozgássebesség – a StaminaManagement állítja be minden frame-ben.
        /// </summary>
        [Header("Még nem kategorizált Stat")]
        public static float gyorsasag = 0f;

        // ── Privát backing fieldek ────────────────────────────────

        private int hp = 100;
        private int stamina = 100;
        private int hunger = 100;
        private int thirst = 100;
        private int maxCarryWeight = 10;

        private bool isDead = false;

        // ── Propertyk ─────────────────────────────────────────────

        public bool IsDead => isDead;

        public int HP
        {
            get => hp;
            set
            {
                if (isDead) return;
                hp = Mathf.Clamp(value, 0, MaxHp);
                OnHPChanged?.Invoke(hp);

                if (hp <= 0 && !isDead)
                {
                    isDead = true;
                    OnDeath?.Invoke();
                }
            }
        }

        public int Stamina
        {
            get => stamina;
            set
            {
                stamina = Mathf.Clamp(value, 0, MaxStamina);
                OnStaminaChanged?.Invoke(stamina);
            }
        }

        public int Hunger
        {
            get => hunger;
            set
            {
                hunger = Mathf.Clamp(value, 0, MaxHunger);
                OnHungerChanged?.Invoke(hunger);
            }
        }

        public int Thirst
        {
            get => thirst;
            set
            {
                thirst = Mathf.Clamp(value, 0, MaxThirst);
                OnThirstChanged?.Invoke(thirst);
            }
        }

        public int Level => level;
        public int MaxCarryWeight => maxCarryWeight;

        // ── Események ─────────────────────────────────────────────

        public event Action<int> OnHPChanged;
        public event Action<int> OnStaminaChanged;
        public event Action<int> OnHungerChanged;
        public event Action<int> OnThirstChanged;

        /// <summary>
        /// Akkor sül el, amikor a HP eléri a 0-t. Csak egyszer hívódik meg.
        /// </summary>
        public event Action OnDeath;
    }
}