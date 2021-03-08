using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class OnHoverActivate : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public GameObject discriptionText;
    bool active = false;

    public void Update()
    {
        //if(active == true)
        //{
        //    discriptionText.SetActive(active);

        //}
        //else
        //{
        //    discriptionText.SetActive(active);
        //}
        //active = false;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        discriptionText.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        discriptionText.SetActive(false);
    }
}
