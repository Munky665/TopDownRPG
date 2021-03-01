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
        if(Input.GetKey(KeyCode.Q))
        {
            skillButtons[0].onClick.Invoke();
        }
        if (Input.GetKey(KeyCode.W))
        {
            skillButtons[1].onClick.Invoke();
        }
        if (Input.GetKey(KeyCode.E))
        {
            skillButtons[2].onClick.Invoke();
        }
        if (Input.GetKey(KeyCode.R))
        {
            skillButtons[3].onClick.Invoke();
        }

    }
}
