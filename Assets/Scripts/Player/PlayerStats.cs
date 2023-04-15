using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{

    public static int Money;

    public float speed;

    public GameObject deathDisplay;

    private void Awake()
    {
        Money = PlayerPrefs.GetInt("Money", 0);
        speed = PlayerPrefs.GetFloat("Speed", 150);
    }
    private void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged (Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }

    public override void TakeDamage(int damage)
    {
        if (Health <= 0)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Death");
            deathDisplay.SetActive(true);

        }
        else if (Health - damage <= 0)
        {
            damage -= armor.GetValue();
            damage = Mathf.Clamp(damage, 0, int.MaxValue);

            Health -= damage;
            healthBar.SetHealth(Health);
            gameObject.GetComponent<Animator>().SetTrigger("Death");
            deathDisplay.SetActive(true);

        }
        else if (Health > 0)
        {
            damage -= armor.GetValue();
            Health -= damage;
            healthBar.SetHealth(Health);
            if (!gameObject.GetComponent<Punch>().makePunch)
            {
                gameObject.GetComponent<Animator>().SetTrigger("Damage");
            }
        }
    }

    public void AddHealth(int health)
    {
        Health += health;
        healthBar.SetHealth(Health);
    }

    public void AddDamage(int damageAdd)
    {
        damage.AddModifier(damageAdd);
    }

    public void AddSpeed(int _speed)
    {
        PlayerPrefs.SetFloat("Speed", speed + _speed);
    }
}
