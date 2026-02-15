using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SpawnManager : MonoBehaviour
{
    //In the GameObject array, you can assign the prefabs you want to spawn.
    //Each prefab should have an ItemValue component that defines its value.
    //The Spawn method will randomly select prefabs from the array and spawn them until the total value of the spawned items reaches the specified spawnValue.
    //They will be spawned within a certain range around the SpawnManager's position
    //You can spawn the items by pressing the "I" key

    public GameObject[] spawnPrefab; 
    public float range = 5f;

    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int randomSpawnValue = UnityEngine.Random.Range(10, 20);
        int randomSpawnCount = UnityEngine.Random.Range(3, 6);


        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Spawn value: " + randomSpawnValue);
            Debug.Log("Spawn count: " + randomSpawnCount);
            Spawn(randomSpawnValue, randomSpawnCount);
        }
    }
    public void Spawn(int spawnValue, int spawnCount)
    {


        int remainingValue = spawnValue, remainingSpawnCount = spawnCount;
        while (remainingValue > 0 && remainingSpawnCount > 0)
        {
            List<GameObject> possibleItems = new List<GameObject>();
            foreach (GameObject item in spawnPrefab)
            {
                ItemValue itemValue = item.GetComponent<ItemValue>();
                if (itemValue != null && itemValue.value <= remainingValue)
                {
                    possibleItems.Add(item);
                }
            }

            if(possibleItems.Count == 0)
            {
                break; // No more items can be spawned
            }

            //Randomly select an item from the possible items
            GameObject selectedItem = possibleItems[UnityEngine.Random.Range(0, possibleItems.Count)];


            int selectedItemValue = selectedItem.GetComponent<ItemValue>().value;

            Vector3 randomPosition = transform.position + UnityEngine.Random.insideUnitSphere * range;
            randomPosition.y = transform.position.y; // Keep the y position consistent

            Instantiate(selectedItem, randomPosition, Quaternion.identity);

            remainingValue -= selectedItemValue;
            remainingSpawnCount--;
        }
        
        
    }
}
