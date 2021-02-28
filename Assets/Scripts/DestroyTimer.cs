using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyThis());
    }
    
    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(3.3f);
        Destroy(this.gameObject);
    }
}
