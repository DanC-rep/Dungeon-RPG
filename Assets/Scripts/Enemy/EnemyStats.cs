using UnityEngine;

public class EnemyStats : CharacterStats
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
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
        else if (Health > 0)
        {
            Health -= damage;
            healthBar.SetHealth(Health);
            gameObject.GetComponent<Animator>().SetTrigger("Damage");
        }
    }
}
