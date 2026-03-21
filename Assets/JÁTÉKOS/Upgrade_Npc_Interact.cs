using UnityEngine;

public class Upgrade_Npc_Interact : MonoBehaviour, IInteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
    public string InteractMessage => $"Press E to interact with {gameObject.name}";
}
