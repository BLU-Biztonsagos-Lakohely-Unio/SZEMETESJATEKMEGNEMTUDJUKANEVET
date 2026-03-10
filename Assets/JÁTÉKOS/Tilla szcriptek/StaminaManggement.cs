using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaManggement : MonoBehaviour
{
    static PALYERSTAT stat;
    static MOZGAS1 mozog;
    float gyorsasag;
    int stamina;
    public bool mehet,fut, ON_OFF;
    Coroutine RegenC;
    void Start()
    {
        mozog = GetComponent<MOZGAS1>();
        stat = GetComponent<PALYERSTAT>();
        stamina = stat.Stamina;
        mozog.Ugras += ugrasminusz;
        InvokeRepeating(nameof(minuszstamina), 1f, 1f);
    }
    // Update is called once per frame
    void Update()
    {
        fut = Input.GetKey(KeyCode.LeftShift);
        bool Sift = Input.GetKey(KeyCode.LeftShift);
        stat.gyorsasag = stat.Stamina >= 20 ? 10f : 5f;
        if (Sift)
        {
            stat.gyorsasag *= 2;
        }
        else
        {
        }
    }
    void ugrasminusz()
    { 
        stat.Stamina -= 10;
        StopRegen();
        ON_OFF = false;
        
    }
    void minuszstamina()
    {
        if (fut) {
            stat.Stamina -= 3;
            StopRegen();
            ON_OFF = false; 
        }
        else { 
            if (!ON_OFF) 
            {
                ON_OFF = true; 
                RegenC = StartCoroutine(STR(5)); 
            }
        }
    }

    void StopRegen()
    {
        if (RegenC != null)
        {
            StopCoroutine(RegenC); 
            RegenC = null;
        }
        ON_OFF = false;
    }

    IEnumerator STR(float sec)
    {

        yield return new WaitForSeconds(sec);
        while (!fut && stat.Stamina < 100) 
        { 
            stat.Stamina += 1; 
            yield return new WaitForSeconds(1f); 
        }

        ON_OFF = false;
        RegenC = null;
    }
}
