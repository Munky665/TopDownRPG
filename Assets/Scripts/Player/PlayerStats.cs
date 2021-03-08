using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Stats
{
    public float exp = 0;
    public float expRequired = 9;
    public int level = 1;
    bool playSound = true;
    public GameObject levelUpParticles;
    public AudioClip levelUp;
    public AudioClip enemyAttackSound;
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
        base.Death();
        PlayerDamageSFX.instance.PlaySound(death);
    }


    public override void Damage(float d)
    {
        base.Damage(d);

        if(playSound)
        {
            StartCoroutine(HurtPlayer());
        }    
        
        if (health <= 0)
        {
            Death();
        }

    }

    IEnumerator HurtPlayer()
    {
        playSound = false;
        EnemySFXManager.instance.PlaySound(enemyAttackSound);
        yield return new WaitForSeconds(0.2f);
        PlayerDamageSFX.instance.PlaySound(hurt);
        yield return new WaitForSeconds(1.8f);
        playSound = true;
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
        maxHealth += 10;
        health = maxHealth;
        maxMana += 5;
        mana = maxMana;
        damage.AddModifier(1);
        exp = temp;
        var particles = Instantiate(levelUpParticles, this.transform);
        particles.transform.position += new Vector3(0, 1, 0);
        UpdateImageFill(health, maxHealth, healthBar);
        UpdateImageFill(mana, maxMana, manaBar);

        SkillManager.instance.EnableSkill(level);
        PlayerSFXManager.instance.PlaySound(hurt);
    }
}
