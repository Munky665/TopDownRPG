using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill/Dash Skill")]
class DashSkill : SkillObject
{
    public override void UseSkill(Animator anim, int skillToActivate, List<GameObject> g)
    {
        base.UseSkill(anim, skillToActivate, g);
        GameManager.instance.StartCoroutine(PlaySkillAnimation(anim, skillToActivate, g));
    }

    IEnumerator PlaySkillAnimation(Animator anim, int skillToActivate, List<GameObject> g)
    {
        var agent = anim.GetComponent<PlayerController>().agent;
        anim.GetComponent<PlayerController>().isDashing = true;
        agent.speed = 100;
        agent.acceleration = 50;
        agent.SetDestination(agent.gameObject.transform.position + agent.gameObject.transform.forward.normalized * 10);
        _ = Instantiate(particleEffect, anim.transform);
        anim.GetComponent<BoxCollider>().enabled = true;
        DoDamage(g);
        yield return new WaitForSeconds(1);
        //DoDamage(g);
        agent.speed = 5;
        agent.acceleration = 15;
        anim.GetComponent<PlayerController>().isDashing = false;
        anim.GetComponent<BoxCollider>().enabled = false;


    }
}

