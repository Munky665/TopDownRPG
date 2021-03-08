using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Stats
{
    float expWorth = 3;
    int oddsOfDroppingPotion = 5;
    int numberInOddsOfDroppingPotion = 3;
    bool playSound = true;
    public AudioClip playerAttackSound;

    private void Start()
    {
        healthBar.enabled = false;
        var wave = GameManager.instance.wave;

        if(wave > 6)
        {
            maxHealth += wave;
            damage.AddModifier(wave - (wave / 2));
            GetComponent<PlayerController>().agent.speed += (wave * 0.1f);
        }
    }

    public override void Death()
    {
        base.Death();
        GetComponent<IController>().agent.isStopped = true;
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        EnemyDamageSFX.instance.PlaySound(death);
        StartCoroutine(DestroyGameObject());
    }
    public override void Damage(float d)
    {
        base.Damage(d);

        if(playSound)
        {
            StartCoroutine(HurtEnemy());
        }

        if (health <= 0)
        {
            Death();
        }

    }


    IEnumerator HurtEnemy()
    {
        playSound = false;
        PlayerSFXManager.instance.PlaySound(playerAttackSound);
        yield return new WaitForSeconds(0.2f);
        EnemyDamageSFX.instance.PlaySound(hurt);
        yield return new WaitForSeconds(1.8f);
        playSound = true;
    }
    IEnumerator DestroyGameObject()
    {
        GameManager.instance.RemoveDeadEnemy(this.gameObject);
        GameManager.instance.AddExp(expWorth);
        ItemManager.instance.SpawnPotion(oddsOfDroppingPotion, numberInOddsOfDroppingPotion, this.gameObject.transform);
        EnemyDamageSFX.instance.PlaySound(death);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    private void OnMouseOver()
    {
        healthBar.enabled = true;
    }

    private void OnMouseExit()
    {
        healthBar.enabled = false;
    }
}
