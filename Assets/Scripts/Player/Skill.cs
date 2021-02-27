using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Skill
{
    [SerializeField]
    private int levelRequired;
    [SerializeField]
    private SkillObject skillObject;

    public virtual void ActivateSkill(Animator anim, int playerLevel)
    {
        if(playerLevel >= levelRequired)
        {
            //activate skill
            skillObject.UseSkill();
        }
        //else
            //do nothing at all, nothing at all, nothing at all
    }

}
