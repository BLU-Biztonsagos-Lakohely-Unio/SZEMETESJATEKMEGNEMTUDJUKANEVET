using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MOZGAS1 : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    bool hozzaer;
    public Transform GC;
    public float atmero = 0.2f;
    public LayerMask Ground;
    float MozgasEH;
    float MozgasJB;
    public float jump = 1000f;
    float gyorsasag=10f;
    
    // Update is called once per frame
    void Update()
    {

        hozzaer = Physics.CheckSphere(GC.position, atmero, Ground);

        if (Input.GetKeyDown(KeyCode.Space) && hozzaer)
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }

        MozgasEH = Input.GetAxis("Horizontal");
        MozgasJB = Input.GetAxis("Vertical");
        //Debug.Log("Grounded: " + hozzaer);
    }
    
    void FixedUpdate() { 
        Vector3 move = transform.right * MozgasEH + transform.forward * MozgasJB;
        rb.MovePosition(rb.position + move * gyorsasag * Time.fixedDeltaTime);
    }
}

