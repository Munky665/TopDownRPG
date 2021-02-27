using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Stats
{
    float exp = 0;
    public float expRequired { get; private set; }
    public int level { get; private set; } = 1;

    private void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }
    //Adds modifiers to player stats and removes old ones
    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }

        if(oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.armorModifier);
        }
    }

    public override void Death()
    {
        anim.SetBool("IsDead", true);
        controller.isDead = true;
    }

    internal void AddExp(float expWorth)
    {
        exp += expWorth;
       //level up if enough xp gained
        if(exp >= expRequired)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        float temp = 0;

        if(exp > expRequired)
        {
            temp = expRequired - exp;
        }

        level++;
        expRequired = level * 10;
        health += 10;
        damage.AddModifier(1);
        exp = temp;
    }
}
