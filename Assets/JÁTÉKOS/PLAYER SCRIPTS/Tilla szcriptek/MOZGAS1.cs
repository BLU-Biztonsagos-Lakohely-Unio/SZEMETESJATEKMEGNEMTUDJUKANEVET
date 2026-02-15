using UnityEngine;

public class MOZGAS1 : MonoBehaviour
{

    void Start()
    {
        
    }
    float MozgasEH;
    float MozgasJB;
    public float jump;
    float gyorsasag=10f;
    // Update is called once per frame
    void Update()
    {
        jump = Input.GetAxis("Jump")*6;
        MozgasEH = Input.GetAxis("Horizontal") ;
        MozgasJB = Input.GetAxis("Vertical");
        transform.Translate( MozgasEH * Time.deltaTime *gyorsasag , Input.GetKeyDown(KeyCode.Space) ? jump * Time.deltaTime * gyorsasag: 0 , MozgasJB * Time.deltaTime * gyorsasag);
        
    }
}

