using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOptionsMenu : MonoBehaviour
{
    public List<GameObject> menuItems;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToDisable());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitToDisable()
    {
        yield return new WaitForSeconds(0.1f);
        foreach (GameObject g in menuItems)
        {
            g.SetActive(false);
        }
    }
}
