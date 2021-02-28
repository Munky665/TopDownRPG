using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnFillImage : MonoBehaviour
{
    public float timer;
    public float maxTimer;
    bool empty = true;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!empty)
        {
            timer -= 1 * Time.deltaTime;
            var ratio = timer / maxTimer;
            image.fillAmount = ratio;

            if(timer <= 0)
            {
                empty = !empty;
                timer = maxTimer;
            }
        }
    }

    public void Activate()
    {
        empty = false;
        image.fillAmount = 1;
    }
}
