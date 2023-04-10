using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Item item;
    public Image icon;
    public Text cost;
    public GameObject sold;

    private bool buy = false;

    private void Start()
    {
        cost.text = item.cost.ToString();
    }

    public void AddToInventory()
    {
        if (PlayerStats.Money - item.cost >= 0 && buy == false)
        {
            item.AddToInventory();
            sold.SetActive(true);
            cost.enabled = false;
            buy = true;
            PlayerStats.Money -= item.cost;
        }
        
    }
}
