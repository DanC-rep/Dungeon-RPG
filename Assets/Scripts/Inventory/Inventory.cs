using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than 1");
            return;
        }

        instance = this;
    }
    #endregion

    public int space = 15;

    public List<Item> items = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Maximum");
            return false; ;
        }
        items.Add(item);

        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
    }
}
