using UnityEngine;

public class Mozgas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    float MozgasEH;
    float MozgasJB;
    public float jump;
    float gyorsaság=10f;
    // Update is called once per frame
    void Update()
    {
        jump = Input.GetAxis("Jump")*6;
        MozgasEH = Input.GetAxis("Horizontal") ;
        MozgasJB = Input.GetAxis("Vertical");
        transform.Translate( MozgasEH * Time.deltaTime *gyorsaság , jump * Time.deltaTime *gyorsaság, MozgasJB * Time.deltaTime * gyorsaság);
        if (Input.GetKey(KeyCode.E)) { transform.Rotate(Vector3.up, 2f) ; }
        if (Input.GetKey(KeyCode.Q)) { transform.Rotate(Vector3.up, -2f) ; }
    }
}
