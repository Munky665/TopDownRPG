using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{

    float fadeTime = 1;
    float darkTime = 0;

    bool paused = false;

    public GameObject text;

    public static FadeScript instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        StartCoroutine(DelayFade());
    }

    //makes black image fade
    public void Fade()
    {
        GetComponent<Image>().CrossFadeAlpha(0, fadeTime, true);
      
    }
    //makes screen black out
    public void Darken()
    {
        GetComponent<Image>().CrossFadeAlpha(1, darkTime, true);
        
    }

    IEnumerator DelayFade()
    {
        yield return new WaitForSeconds(2);
        if (text != null)
        {
            text.SetActive(false);
        }
        Fade();
    }
}
