using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStats playerStats;
    public HealthBar healthBar;


    private void Start()
    {
        healthBar.SetMaxHealth(playerStats.Health);
    }

    private void DestroyPlayerEvent()
    {
        Destroy(gameObject);
    }
}
