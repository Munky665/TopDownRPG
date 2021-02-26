using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown = 1f;
    Stats myStats;

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
            targetStats.Damage(myStats.damage.GetValue());
            attackCooldown = 1f / attackSpeed;
        }

    }
}
