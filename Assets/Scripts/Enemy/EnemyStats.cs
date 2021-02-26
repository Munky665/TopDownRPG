using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Stats
{
    float expWorth = 3;

    private void Start()
    {
        healthBar.enabled = false;
    }

    public override void Death()
    {
        base.Death();
        GetComponent<IController>().agent.isStopped = true;
        StartCoroutine(DestroyGameObject());
    }

    IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(5);
        GameManager.instance.RemoveDeadEnemy(this.gameObject);
        GameManager.instance.AddExp(expWorth);
        Destroy(gameObject);
    }

    private void OnMouseOver()
    {
        healthBar.enabled = true;
    }

    private void OnMouseExit()
    {
        healthBar.enabled = false;
    }
}
