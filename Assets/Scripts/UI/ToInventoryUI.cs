using UnityEngine;

public class ToInventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject otherUI;

    public void OpenInventory()
    {
        inventoryUI.SetActive(true);
        otherUI.SetActive(false);
    }
}
