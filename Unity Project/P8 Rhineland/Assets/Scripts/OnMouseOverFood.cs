using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseOverFood : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject foodUiHolder;

    public void OnPointerEnter(PointerEventData eventData)
    {
        foodUiHolder.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foodUiHolder.SetActive(false);
    }

}
