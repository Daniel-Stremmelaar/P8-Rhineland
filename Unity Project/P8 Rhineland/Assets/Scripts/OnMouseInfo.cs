using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject buildingInfoHolder;

    private void Start()
    {
        buildingInfoHolder.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("KANKER CHINEES");
        buildingInfoHolder.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("KANKER CHINEES V2");
        buildingInfoHolder.SetActive(false);
    }
}
