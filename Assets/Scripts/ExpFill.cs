using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpFill : MonoBehaviour
{
    public PlayerStats pS;
    public Image expBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ratio = pS.exp / pS.expRequired;
        expBar.fillAmount = ratio;
    }
}
