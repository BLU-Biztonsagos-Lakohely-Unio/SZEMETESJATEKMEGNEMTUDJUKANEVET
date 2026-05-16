using Unity.VisualScripting;
using UnityEngine;

public class UpgradeMenu_manager : MonoBehaviour, IInteractable
{
    public GameObject Upgrade_Menu;
    private bool isUpgradeMenuOpen = false;
    void Start()
    {
    }

    public void Interact()
    {

        ToggleUpgradeMenu();

    }

    void ToggleUpgradeMenu()
    {
        isUpgradeMenuOpen = !isUpgradeMenuOpen;
        Upgrade_Menu.SetActive(isUpgradeMenuOpen);

        // játék megállítása / folytatása
        Time.timeScale = isUpgradeMenuOpen ? 0f : 1f;

        // kurzor kezelése
        Cursor.visible = isUpgradeMenuOpen;
        Cursor.lockState = isUpgradeMenuOpen ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public string InteractMessage => $"Press E to interact with {gameObject.name}";
}

