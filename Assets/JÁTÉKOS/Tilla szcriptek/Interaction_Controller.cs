using UnityEngine;
using TMPro;

public class Interaction_Controller : MonoBehaviour
{
    [SerializeField]
    Camera playerCamera;

    [SerializeField]
    TextMeshProUGUI interactionText;

    [SerializeField]
    float interactionDistance = 5f;

    IInteractable currentTargetedInteractible;

    public void Update()
    {
        UpdateCurrentInteractible();
        UpdateInteractionText();
        ChechForInteractionInput();

    }

    void UpdateCurrentInteractible() {         
        var ray = playerCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));

        Physics.Raycast(ray, out var hit, interactionDistance);
        
        currentTargetedInteractible = hit.collider?.GetComponent<IInteractable>();
    }

    void UpdateInteractionText()
    {
        if(currentTargetedInteractible == null)
        {
            interactionText.text = string.Empty;
        }
        else
        {
            interactionText.text = currentTargetedInteractible.InteractMessage;
        }
    }

    void ChechForInteractionInput()
    {
        if(Input.GetKeyDown(KeyCode.E) && currentTargetedInteractible != null)
        {
            currentTargetedInteractible.Interact();
        }
    }
}
