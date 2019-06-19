using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseOverFood : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("KANKER CHINEES");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("");
    }

}
