using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UIManager uIManager;

    public void OnPointerEnter(PointerEventData eventData)
    {
        uIManager.buildingInfoHolder.SetActive(true);
        Debug.Log(gameObject.name + " hahahaha");

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uIManager.buildingInfoHolder.SetActive(false);
    }
}
