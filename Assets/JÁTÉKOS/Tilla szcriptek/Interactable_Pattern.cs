using UnityEngine;

public class Interactable_Pattern : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
    public string InteractMessage => $"Press E to interact with {gameObject.name}";
}
