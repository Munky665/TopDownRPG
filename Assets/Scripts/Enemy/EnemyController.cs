using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : IController
{
    public float lookRadius = 10f;

    Transform alternateTarget;
    GameManager gM;
    CharacterCombat combat;
    GameObject attackTarget;
    float playerMinDistance = 1.5f;
    float totumMinDistance = 2.0f;
    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameManager.instance;
        target = gM.player.transform;
        alternateTarget = gM.totum.transform;
        anim = GetComponent<Animator>();
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("IsAttacking", false);

        var playerMag = transform.position - target.position;
        var totumMag = transform.position - alternateTarget.position;

        float mag;
        Vector3 targetPos;
        float minDistance;
        if (!isDead)
        {
            if (playerMag.magnitude > lookRadius)
            {
                mag = totumMag.magnitude;
                targetPos = alternateTarget.position;
                minDistance = totumMinDistance;
                attackTarget = alternateTarget.gameObject;
            }
            else
            {
                mag = playerMag.magnitude;
                targetPos = target.position;
                minDistance = playerMinDistance;
                attackTarget = target.gameObject;
            }



            if (mag < minDistance)
            {
                Stats targetStats = attackTarget.GetComponent<Stats>();
                if (targetStats != null)
                {
                    combat.Attack(targetStats);
                    EnemySFXManager.instance.PlaySound(sound);
                }
                agent.SetDestination(transform.position);
                anim.SetBool("IsMoving", isMoving = false);
                anim.SetBool("IsAttacking", isAttacking = true);
                FaceTarget(targetPos);
            }
            else
            {
                agent.SetDestination(targetPos);
                anim.SetBool("IsMoving", isMoving = true);
            }
        }   
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }


}
