using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float Speed;
    public SphereCollider blastRadius;
    public List<GameObject> enemiesInRadius;
    public float damage;
    public Vector3 forward;
    // Start is called before the first frame update
    void Start()
    {
        blastRadius.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (blastRadius.enabled == false)
        {
            transform.position += forward * Speed * Time.deltaTime;
        }
        else
        {
            foreach(GameObject g in enemiesInRadius)
            {
                g.GetComponent<Stats>().Damage(damage);
            }
            StopCoroutine(TimeOut());
            Destroy(this.gameObject);
        }

        StartCoroutine(TimeOut());
    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!enemiesInRadius.Contains(other.gameObject))
        {
            if (other.gameObject.tag == "Enemy")
            {
                enemiesInRadius.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            blastRadius.enabled = true;
        }
    }
}
