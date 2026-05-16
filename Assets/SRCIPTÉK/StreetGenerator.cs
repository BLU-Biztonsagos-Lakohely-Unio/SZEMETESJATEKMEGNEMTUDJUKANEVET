using UnityEngine;

public class StreetGenerator : MonoBehaviour
{
    public GameObject roadPrefab; //az út 40 méter hosszú és 32(?) méter széles
    public GameObject[] Houses; //a house2: 30méter széles és kb 25 méter hosszú


    
    //valamiért nem megy át a számok módosítása a prefabokra
    public int streetLength = 4; 
    public int lengthZ = 2; 

    public float spacingX = 3f;
    public float spacingZ = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GenerateStreet();
        }
    }
    public void GenerateRoad(Vector3 start, int lenth)
    {
        

        Renderer[] rends = roadPrefab.GetComponentsInChildren<Renderer>();
        Debug.Log(GetComponentsInChildren<Renderer>().Length);
        Bounds bounds = rends[0].bounds;

        foreach (Renderer r in rends)
        {
            bounds.Encapsulate(r.bounds);
        }

        float útHossz = bounds.size.x;
        for (int i = 0; i < lenth; i++)
        {
            Vector3 position = start + new Vector3(i * útHossz, 0.1f, 0);
            Debug.Log($"Spawning road at position: {position}");
            Instantiate(roadPrefab, position, Quaternion.identity);
        }
    }
    public void GenerateStreet()
    {
        
         Vector3 starterPos = new Vector3(transform.position.x, 0, transform.position.z);
         GenerateRoad(starterPos, streetLength);

         //ház spawnolása
         GameObject housePrefab = Houses[Random.Range(0, Houses.Length)];
         //Instantiate(housePrefab, position + new Vector3(0, 3.33f, spacingX), Quaternion.identity);
        
    }

}
