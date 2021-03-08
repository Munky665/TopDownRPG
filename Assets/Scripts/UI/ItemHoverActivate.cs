using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHoverActivate : MonoBehaviour
{
    public GameObject discriptionText;

    private void OnMouseOver()
    {
        discriptionText.SetActive(true);
    }

    private void OnMouseExit()
    {
        discriptionText.SetActive(false);
    }
}
