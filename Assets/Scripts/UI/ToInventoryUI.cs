using UnityEngine;

public class ToInventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject[] otherUI;

    public void OpenInventory()
    {
        inventoryUI.SetActive(true);
        foreach (var UI in otherUI)
        {
            UI.SetActive(false);
        }
    }
}
