using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBarController : MonoBehaviour
{
    public List<Button> skillButtons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (skillButtons[0].enabled)
            {
                skillButtons[0].onClick.Invoke();
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (skillButtons[2].enabled)
            {
                skillButtons[1].onClick.Invoke();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (skillButtons[2].enabled)
            {
                skillButtons[2].onClick.Invoke();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (skillButtons[3].enabled)
            {
                skillButtons[3].onClick.Invoke();
            }
        }

    }
}
