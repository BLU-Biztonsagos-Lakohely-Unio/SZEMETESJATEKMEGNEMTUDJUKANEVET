using System;
using UnityEngine;

public class KAMERAMOZGÁS : MonoBehaviour
{

    
    public float mouseSensitivity = 100f;

    
    public Transform playerBody; 
    public Transform playerCamera; 

    private float xRotation = 0f; 

    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform.parent;
        playerCamera = transform;
    }

    void Update()
    {
        //BEKÉRÉS SZEX
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // EMIAT NNEM  FORDULIK MEGFELE

        try { playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f); }
        catch { Console.WriteLine("FASZ"); }

        
        playerBody.Rotate(Vector3.up * mouseX);
    }
}



