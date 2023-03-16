using UnityEngine;
public class CharacterStats :MonoBehaviour
{
    public Stat damage;
    public Stat armor;

    public int Health;
    public int startHealth = 100;

    public static float range = 4f;

    private void Awake()
    {
        Health = startHealth;
    }

    public void TakeDamage(int damage)
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
