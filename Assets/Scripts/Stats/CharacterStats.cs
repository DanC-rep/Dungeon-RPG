using UnityEngine;
public class CharacterStats :MonoBehaviour
{
    public Stat damage;
    public Stat armor;

    [HideInInspector]
    public int Health;

    public int startHealth = 100;

    public static float range = 4f;

    public HealthBar healthBar;

    private void Awake()
    {
        Health = startHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        Health -= damage;

        if(Health <= 0)
            Die();
    }

    public virtual void Die()
    {
        // Die
    }
}
