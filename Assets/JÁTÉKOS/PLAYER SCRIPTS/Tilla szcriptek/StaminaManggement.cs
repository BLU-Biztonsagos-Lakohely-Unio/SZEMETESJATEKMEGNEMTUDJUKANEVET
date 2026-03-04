using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaManggement : MonoBehaviour
{
    static PALYERSTAT stat;
    static MOZGAS1 mozog;
    float gyorsasag;
    int stamina;
    bool mehet,fut, ON_OFF;
    void Start()
    {
        mozog = GetComponent<MOZGAS1>();
        stat = GetComponent<PALYERSTAT>();
        gyorsasag = stat.gyorsasag;
        stamina = stat.Stamina;
        mozog.Ugras += ugrasminusz;
        InvokeRepeating(nameof(minuszstamina), 1f, 1f);
    }
    // Update is called once per frame
    void Update()
    {
        bool Sift = Input.GetKey(KeyCode.LeftShift);
        gyorsasag = stamina >0 ? 10f : 5f;
        if (Sift && stat.Stamina > 30 || mehet && Sift)
        {
            gyorsasag = gyorsasag * 2;
            fut = true;
            mehet = true;
        }
        else
        {
            fut = false;
            mehet = false;
        }
        
    }
    void ugrasminusz()
    {
        stat.Stamina -= 10;
        StopCoroutine(STR(5));
        ON_OFF = false;
    }
    void minuszstamina()
    {
        if (fut) {
            stat.Stamina -= 3;
            StopCoroutine(STR(5)); 
            ON_OFF = false; 
        }
        else { 
            if (!ON_OFF) 
            {
                ON_OFF = true; 
                StartCoroutine(STR(5)); 
            }
        }
        if (stat.Stamina > 100) 
        { 
            stat.Stamina = 100; 
        }
        if (stat.Stamina < 0)
        {
            stat.Stamina = 0;
        }
    }


    IEnumerator STR(float sec)
    {

        yield return new WaitForSeconds(sec);
        while (!fut && stat.Stamina < 100) 
        { 
            stat.Stamina += 1; 
            yield return new WaitForSeconds(2f); 
        }

        ON_OFF = false;

    }
}
