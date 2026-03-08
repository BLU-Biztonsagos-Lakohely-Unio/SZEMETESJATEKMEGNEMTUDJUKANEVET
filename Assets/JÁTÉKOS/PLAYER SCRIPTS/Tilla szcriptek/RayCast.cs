using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    List<ItemData> adatok = new List<ItemData>();
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 5f))
        {
            
            ItemData itemData = hitInfo.collider.GetComponent<ItemData>();
            
            if (itemData != null) 
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    adatok.Add(itemData);
                    Debug.Log("Felvett tárgy: " + itemData.ToString());
                }
            }
            
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Inventory:");
            Debug.Log("---------");
            Debug.Log("Tárgyak száma: " + adatok.Count);
            foreach (var item in adatok)
            {
                Debug.Log(item.name);
            }
        }
    }
    
}
