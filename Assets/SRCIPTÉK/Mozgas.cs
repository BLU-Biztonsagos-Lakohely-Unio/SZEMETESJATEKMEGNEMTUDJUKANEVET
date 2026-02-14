using UnityEngine;

public class NewMonoBehaviourScript1 : MonoBehaviour
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
        if (jump == 0 && transform.position.y > 3) { transform.Translate(MozgasEH * Time.deltaTime, Time.deltaTime * -1 * gyorsaság * 6, MozgasJB * Time.deltaTime); }
        transform.Translate( MozgasEH * Time.deltaTime *gyorsaság , jump * Time.deltaTime *gyorsaság, MozgasJB * Time.deltaTime * gyorsaság);

    }
}
