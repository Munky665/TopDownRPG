using UnityEngine;

[System.Serializable]
public class Skill
{
    [SerializeField]
    public int levelRequired;

    public SkillObject skillObject;
    public float timer = 0;
    public bool coolingDown = true;
   
    public bool checkCooling = true;
    public virtual void ActivateSkill(PlayerController pC, int skillToActivate, PlayerStats playerStats)
    {

        if (playerStats.level >= levelRequired && skillObject.manaCost < playerStats.mana)
        {
            if (coolingDown == false)
            {
                timer = skillObject.cooldown;
                coolingDown = true;
                playerStats.UseMana(skillObject.manaCost);
                //activate skill
                skillObject.UseSkill(pC.GetComponent<Animator>(), skillToActivate, pC.closeEnemies);
                coolingDown = true;
                checkCooling = true;
            }
        }
        else if(coolingDown == true && skillObject.manaCost > playerStats.mana)
        {
            pC.GetComponent<Animator>().SetBool("IsUsingSkill", false);
        }
        
        //else
        //do nothing at all, nothing at all, nothing at all
    }

    public void cooldown(PlayerStats playerStats)
    {
        if (playerStats.level >= levelRequired && coolingDown == true)
        {
            coolingDown = false;
        }
    }
}
