using System;
using UnityEngine;
using PS;
/// <summary>
/// Kezeli a játékos mozgását és ugrását Rigidbody segítségével.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PALYERSTAT))]
public class MOZGAS1 : MonoBehaviour
{
    [Header("Ugrás")]
    public float jumpEreje = 100f;
    [Header("Talaj érzékelés")]
    public Transform groundCheck;
    public float groundCheckSugár = 0.2f;
    public LayerMask groundLayer;
    /// <summary>
    /// Esemény – a StaminaManagement figyeli az ugrás stamina-levonásához.
    /// </summary>
    public event Action Ugras;
    private Rigidbody rb;
    private PALYERSTAT stat;
    private float mozgasVizszintes;
    private float mozgasFuggoleges;
    private bool talajonVan;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stat = GetComponent<PALYERSTAT>();
        // Ha a játékos meghal, befagyasztjuk a fizikát
        stat.OnDeath += OnHalalas;
    }
    void Update()
    {
        // Halott játékos nem mozog
        //if (stat.IsDead) return;
        talajonVan = Physics.CheckSphere(groundCheck.position, groundCheckSugár, groundLayer);
        Debug.Log("Talajon van: " + talajonVan + Input.GetKeyDown(KeyCode.Space));
        if (Input.GetKeyDown(KeyCode.Space) && talajonVan && stat.Stamina >= 10)
        {
            Debug.Log("Ugrás!");
            rb.AddForce(Vector3.up * jumpEreje, ForceMode.Impulse);
            Ugras?.Invoke();
        }
        mozgasVizszintes = Input.GetAxis("Horizontal");
        mozgasFuggoleges = Input.GetAxis("Vertical");
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
    }
    void FixedUpdate()
    {
        
        if (stat.IsDead) return;

        Vector3 irany = transform.right * mozgasVizszintes + transform.forward * mozgasFuggoleges;
       
        Vector3 ujSebesseg = irany * PALYERSTAT.gyorsasag;
        ujSebesseg.y = rb.linearVelocity.y;

        rb.linearVelocity = ujSebesseg;
    }
    /// <summary>
    /// Halálkor befagyasztja a Rigidbody-t, hogy a test ne csússzon el.
    /// </summary>
    private void OnHalalas()
    {
        rb.linearVelocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    // ── Gizmo: talaj érzékelő gömb megjelenítése a Scene nézetben ─
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckSugár);
    }
}