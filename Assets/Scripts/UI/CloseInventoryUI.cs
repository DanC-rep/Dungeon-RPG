using UnityEngine;

public class CloseInventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject[] otherUI;

    public void CloseInventory()
    {
        inventoryUI.SetActive(false);

        foreach (var UI in otherUI)
        {
            UI.SetActive(true);
        }
    }
}
