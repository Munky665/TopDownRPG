using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown = 1f;
    Stats myStats;
    public float attackDelay = .5f;
    //public AudioClip sound;
    private void Start()
    {
        myStats = GetComponent<Stats>();
    }
    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }
    public void Attack(Stats targetStats)
    {
        if(attackCooldown <= 0)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));
            attackCooldown = 1f / attackSpeed;
        }

    }

    IEnumerator DoDamage(Stats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (!stats.GetComponent<IController>().isDead)
        {
            stats.Damage(myStats.damage.GetValue());
        }
    }
}
