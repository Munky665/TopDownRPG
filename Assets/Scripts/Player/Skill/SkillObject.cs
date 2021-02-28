using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Skill", menuName ="Skill/Player Skill")]
public class SkillObject : ScriptableObject
{
    new public string name = "New Skill";
    public Sprite icon = null;
    public GameObject particleEffect;
    public int damage;
    public int manaCost;
    public float cooldown;

    public virtual void UseSkill(Animator anim, int skillToActivate, List<GameObject> g)
    {
        //use the Skill
        //something might happen

        Debug.Log("Using " + name);
    }

    public virtual void DoDamage(List<GameObject> enemies)
    {
        foreach (GameObject g in enemies)
        {
            g.GetComponent<Stats>().Damage(damage);
        }
    }

}
