using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
[RequireComponent(typeof(Rigidbody))]
public class MOZGAS1 : MonoBehaviour
{
    Rigidbody rb;
    PALYERSTAT stat;
    Canvas canvas;
    bool ON_OFF;
    public TextMeshProUGUI HP,St;
    void Start()
    { 
        canvas = GetComponentInChildren<Canvas>();
       
        stat = GetComponent<PALYERSTAT>();
        InvokeRepeating(nameof(minuszstamina), 1f, 1f);
        
        rb = GetComponent<Rigidbody>();
    }
    bool hozzaer;
    public Transform GC;
    public float atmero = 0.2f;
    public LayerMask Ground;
    float MozgasEH;
    float MozgasJB;
    public float jump = 1000f;
    public float gyorsasag;
    bool fut, mehet;
    // Update is called once per frame
    void Update()
    {
        
         
       

        if (stat.stamina <= 0)
        {
            gyorsasag = 5f;
        }
        else
        {
            gyorsasag = 10f;
        }
        if (Input.GetKey(KeyCode.LeftShift) && stat.stamina >30 || mehet && Input.GetKey(KeyCode.LeftShift))
        {
            gyorsasag = gyorsasag*2;
            fut = true;
            mehet = true;
        }
        else
        {
            fut = false;
            mehet = false;
        }
        hozzaer = Physics.CheckSphere(GC.position, atmero, Ground);

        if (Input.GetKeyDown(KeyCode.Space) && hozzaer)
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            stat.stamina -= 10; 
            StopCoroutine(staminarecovery(5)); 
            ON_OFF = false;
        }

        MozgasEH = Input.GetAxis("Horizontal");
        MozgasJB = Input.GetAxis("Vertical");
        Debug.Log("Grounded: " + hozzaer);
    }

    void FixedUpdate() {
        Vector3 move = transform.right * MozgasEH + transform.forward * MozgasJB;
        rb.MovePosition(rb.position + move * gyorsasag * Time.fixedDeltaTime);
        HP.text = $" HP :\t {stat.HP}";
        St.text = $" ST :\t {stat.stamina}";
        
        
    }
    void minuszstamina()
    {
        if (fut) { stat.stamina -= 3; StopCoroutine(staminarecovery(5)); ON_OFF = false; }
        else { if (!ON_OFF) { ON_OFF = true; StartCoroutine(staminarecovery(5)); } }
        if (stat.stamina > 100) { stat.stamina = 100; }
        if (stat.stamina < 0)
        {
            stat.stamina = 0;
        }
    }   
    

    IEnumerator staminarecovery(float sec)
    {
        
        yield return new WaitForSeconds(sec);
        while (!fut && stat.stamina <100) { stat.stamina += 1; yield return new WaitForSeconds(2f);}
       
        ON_OFF = false;
        
    }
}

