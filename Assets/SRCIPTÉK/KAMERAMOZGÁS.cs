using UnityEngine;

public class KAMERAMOZGÁS : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public GameObject Player;
    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + new Vector3(0, 5, -5);
    }
}
