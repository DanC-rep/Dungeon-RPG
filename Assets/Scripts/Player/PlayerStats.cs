using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{

    public int startMoney = 0;
    public static int Money;

    private void Awake()
    {
        Money = startMoney;
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
        }
        else if (Health - damage <= 0)
        {
            damage -= armor.GetValue();
            damage = Mathf.Clamp(damage, 0, int.MaxValue);

            Health -= damage;
            healthBar.SetHealth(Health);
            gameObject.GetComponent<Animator>().SetTrigger("Death");

        }
        else if (Health > 0)
        {
            Health -= damage;
            healthBar.SetHealth(Health);
            if (!gameObject.GetComponent<Punch>().makePunch)
            {
                gameObject.GetComponent<Animator>().SetTrigger("Damage");
            }
        }
    }
}
