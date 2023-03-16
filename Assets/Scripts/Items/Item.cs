using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New item";
    public Sprite icon;
    public SkinnedMeshRenderer prefab;

    public virtual void Use()
    {
        Debug.Log("Using" + itemName);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
