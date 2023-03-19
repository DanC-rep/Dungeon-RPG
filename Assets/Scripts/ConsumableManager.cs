using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableManager : MonoBehaviour
{
    #region Singleton
    public static ConsumableManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public PlayerStats playerStats; 

    public void AddBafs(Ñonsumable item)
    {
        playerStats.AddHealth(item.healAmount);
        Debug.Log("Added Health");
    }
}
