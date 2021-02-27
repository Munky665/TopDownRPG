using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObject : ScriptableObject
{
    new public string name = "New Skill";
    public Sprite icon = null;
    public GameObject particleEffect;

    public virtual void UseSkill()
    {
        //use the Skill
        //something might happen

        Debug.Log("Using " + name);
    }

}
