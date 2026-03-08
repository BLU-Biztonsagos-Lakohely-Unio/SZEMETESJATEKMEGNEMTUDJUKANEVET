using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using System;
[RequireComponent(typeof(Rigidbody))]
public class MOZGAS1 : MonoBehaviour
{
    Rigidbody rb;
    static PALYERSTAT stat;
    bool hozzaer;
    public Transform GC;
    public float atmero = 0.2f;
    public LayerMask Ground;
    float MozgasEH;
    float MozgasJB;
    public float jump = 100f;
    public event Action Ugras;
    float gyorsasag;
    void Start()
    { 
        stat = GetComponent<PALYERSTAT>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        hozzaer = Physics.CheckSphere(GC.position, atmero, Ground);

        if (Input.GetKeyDown(KeyCode.Space) && hozzaer)
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            Ugras?.Invoke();
        }

        MozgasEH = Input.GetAxis("Horizontal");
        MozgasJB = Input.GetAxis("Vertical");
        
    }

    void FixedUpdate() {
        gyorsasag = stat.gyorsasag;
        Vector3 move = transform.right * MozgasEH + transform.forward * MozgasJB;
        rb.MovePosition(rb.position + move * gyorsasag * Time.fixedDeltaTime);
    }
    
}

