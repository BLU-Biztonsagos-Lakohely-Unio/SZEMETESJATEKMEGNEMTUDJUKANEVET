using UnityEngine;
using TMPro;
using System;
using System.Collections;
using Game.AI;

public class BESZÉD : MonoBehaviour, IInteractable
{
       NPC npc;
    GameObject Player;
    public TextMeshProUGUI szoveg;
        public GameObject PAnel;
        public string[] Szoveg;
        public TXSpeed Seb;
        int index;

    public string InteractMessage => "NPC";
         void Awake()
             {
                npc = GetComponentInParent<NPC>();
                Player = GameObject.FindGameObjectWithTag("Player");    
    }
    void Start()
        {
        
        }
        

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Kattintás érzékelve");
                if (szoveg.text == Szoveg[index])
                {
                    Debug.Log("Szöveg teljesen megjelenítve, továbblépés");
                    Következö();
                }
                else
                {
                    Debug.Log("Szöveg még nem teljesen megjelenítve, azonnali megjelenítés");
                    StopAllCoroutines();
                    szoveg.text = Szoveg[index];
                }
            }
            else
            {
                Debug.Log("Nem kattintás, figyelmen kívül hagyva");
            }
        }

        public enum TXSpeed
        {
            Lassu,
            Kozepes,
            Gyors
        }
        void kiir()
        {
            index = 0;
            StartCoroutine(Kiiratas());
        }

        IEnumerator Kiiratas()
        {
            foreach (char c in Szoveg[index])
            {
                szoveg.text += c;
                switch (Seb)
                {
                    case TXSpeed.Lassu:
                        yield return new WaitForSeconds(0.2f);
                        break;
                    case TXSpeed.Kozepes:
                        yield return new WaitForSeconds(0.1f);
                        break;
                    case TXSpeed.Gyors:
                        yield return new WaitForSeconds(0.05f);
                        break;
                }
            }
        }

        void Következö()
        {
        if (index < Szoveg.Length - 1)
        {
            index++;
            szoveg.text = string.Empty;
            StartCoroutine(Kiiratas());
        }
        else
        {
            PAnel.SetActive(false);
            Járkál.fStop = false;
            npc.agent.isStopped = false;

        }
        
        }

    public void Interact()
    {
        npc.agent.isStopped = true;

        Vector3 direction = Player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
        
        Járkál.fStop = true;
        PAnel.SetActive(true);
        szoveg.text = string.Empty;
        kiir();
    }
}
