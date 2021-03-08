using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    public List<Button> skills;
    public List<UnFillImage> cooldowns;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        foreach(Button i in skills)
        {
            i.enabled = false;
        }
    }

    public void EnableSkill(int level)
    {
        switch (level)
        {
            case 2:
                cooldowns[0].Activate();
                skills[0].enabled = true;
                break;
            case 4:
                cooldowns[1].Activate();
                skills[1].enabled = true;
                break;
            case 9:
                cooldowns[2].Activate();
                skills[2].enabled = true;
                break;
            case 11:
                cooldowns[3].Activate();
                skills[3].enabled = true;
                break;
            default:
                break;
        }

    }

}
