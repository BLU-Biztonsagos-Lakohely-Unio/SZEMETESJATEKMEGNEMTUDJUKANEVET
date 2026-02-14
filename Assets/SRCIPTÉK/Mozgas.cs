using UnityEngine;

public class NewMonoBehaviourScript1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    float MozgasEH;
    float MozgasJB;
    // Update is called once per frame
    void Update()
    {
        MozgasEH = Input.GetAxis("Horizontal");
        MozgasJB = Input.GetAxis("Vertical");
        transform.Translate( MozgasEH * Time.deltaTime , 0, MozgasJB * Time.deltaTime);

    }
}
