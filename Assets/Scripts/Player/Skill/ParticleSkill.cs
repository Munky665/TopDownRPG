using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill/Particle Skill")]
public class ParticleSkill : SkillObject
{
    public float animationLength = 3f;
    float animationSpawnDelay = 0.5f;
    public override void UseSkill(Animator anim, int skillToActivate, List<GameObject> g)
    {
        base.UseSkill(anim, skillToActivate, g);
        GameManager.instance.StartCoroutine(PlaySkillAnimation(anim, skillToActivate, g));
    }

    IEnumerator PlaySkillAnimation(Animator anim, int skillToActivate, List<GameObject> g)
    {
        anim.SetBool("IsAttacking", false);
        anim.SetBool("IsMoving", false);
        anim.SetBool("IsUsingSkill", true);
        anim.SetInteger("SkillUsed", skillToActivate);
        yield return new WaitForSeconds(animationSpawnDelay);
        var gameObj = Instantiate(particleEffect, anim.transform.position + new Vector3(0, 2, 0), Quaternion.identity);
        var temp = gameObj.GetComponent<ProjectileController>();
        if (temp != null)
        {
            temp.damage = damage;
            temp.forward = anim.gameObject.transform.forward;
        }
        yield return new WaitForSeconds(animationLength - animationSpawnDelay);
        DoDamage(g);
        anim.SetBool("IsUsingSkill", false);
    }
}