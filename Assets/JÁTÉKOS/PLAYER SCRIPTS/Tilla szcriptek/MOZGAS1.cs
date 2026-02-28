using TMPro;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
[RequireComponent(typeof(Rigidbody))]
public class MOZGAS1 : MonoBehaviour
{
    Rigidbody rb;
    PALYERSTAT stat;
    Canvas canvas;
    TextMeshProUGUI HP,St;
    void Start()
    { 
        canvas = GetComponentInChildren<Canvas>();
        HP = canvas.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        St = canvas.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI >();
        stat = GetComponent<PALYERSTAT>();
        InvokeRepeating(nameof(minuszstamina), 5f, 5f);
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
    bool fut;
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            gyorsasag = gyorsasag*2;
            fut = true;
        }
        else
        {
            fut = false;
        }
        hozzaer = Physics.CheckSphere(GC.position, atmero, Ground);

        if (Input.GetKeyDown(KeyCode.Space) && hozzaer)
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
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
        minuszstamina();
    }
    void minuszstamina()
    {
         ;
        if (fut) { stat.stamina -= 20;}
        else {  }
        if (stat.stamina > 100) { stat.stamina = 100; }
        if (stat.stamina < 0) { stat.stamina = 0; stat.HP = -1; }

    }
}

