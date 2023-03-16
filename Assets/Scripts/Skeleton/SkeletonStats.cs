using UnityEngine;
public class SkeletonStats : CharacterStats
{
    public int moneyFrom;

    public override void TakeDamage(int damage)
    {
        if (Health <= 0)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Death");
        }
        else if (Health - damage <= 0)
        {
            Health -= damage;
            healthBar.SetHealth(Health);
            gameObject.GetComponent<Animator>().SetTrigger("Death");
        }
        else if (Health > 0)
        {
            damage -= armor.GetValue();
            damage = Mathf.Clamp(damage, 0, int.MaxValue);

            Health -= damage;

            if (Health <= 0)
                gameObject.GetComponent<Animator>().SetTrigger("Damage");
        }
    }
}
