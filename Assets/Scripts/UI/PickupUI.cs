using UnityEngine;
using UnityEngine.UI;

public class PickupUI : MonoBehaviour
{
    public PlayerController playerController;

    public Button pickupButton;


    private void Update()
    {
        Pickup();
    }

    void Pickup()
    {
        if (playerController.interact != null)
        {
            if (playerController.interact.interactible == true)
            {
                pickupButton.interactable = true;
            }
            else
            {
                pickupButton.interactable = false;
            }
        }
    }

    public void Interact()
    {
        if (playerController.interact != null && playerController.interact.name == "door")
        {
            playerController.interact.OpenDoor(playerController.interact.gameObject);
        }
        else if (playerController.interact != null && playerController.interact.tag == "Item")
        {
            playerController.interact.PickupItem();
        }
        
    }
}
