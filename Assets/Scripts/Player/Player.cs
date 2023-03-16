using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStats playerStats;
    public HealthBar healthBar;
    public HandPunch handPunch;

    private Animator anim;

    private void Start()
    {
        healthBar.SetMaxHealth(playerStats.Health);

        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {

        if (playerStats.Health <= 0)
        {
            anim.SetTrigger("Death");
        }
        else if (playerStats.Health - damage <= 0)
        {
            playerStats.Health -= damage;
            healthBar.SetHealth(playerStats.Health);
            anim.SetTrigger("Death");
            
        }
        else if (playerStats.Health > 0)
        {
            playerStats.Health -= damage;
            healthBar.SetHealth(playerStats.Health);
            if (!handPunch.makePunch)
            {
                anim.SetTrigger("Damage");
            }
        }
    }

    private void DestroyPlayerEvent()
    {
        Destroy(gameObject);
    }
}
