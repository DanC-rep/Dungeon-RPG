using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject otherUI;

    public void CloseInventory()
    {
        inventoryUI.SetActive(false);
        otherUI.SetActive(true);
    }
}
