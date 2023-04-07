using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Сonsumable : Item
{
    public int healAmount;
    public int damageAmount;
    public int speedAmount;

    public override void Use()
    {
        base.Use();

        ConsumableManager.instance.AddBafs(this);
        RemoveFromInventory();
    }
}
