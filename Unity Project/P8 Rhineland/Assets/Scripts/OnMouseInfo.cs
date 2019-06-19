using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnMouseInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UIManager uIManager;
    public Builder builder;
    int index;

    public void OnPointerEnter(PointerEventData eventData)
    {
        uIManager.buildingInfoHolder.SetActive(true);
        Debug.Log(transform.GetChild(0).name);
        //kijk in lijst welke hij is
        if (!transform.GetChild(0).GetComponent<Button>())
        {
            transform.GetChild(1);
        }
        else
        {
            for (int i = 0; i < builder.buttons.Count; i++)
            {
                if (transform.GetChild(0).name == builder.buttons[i].name)
                {
                    index = i;
                    break;
                }
            }

        }


        //krijg de waardes
        //set de waardes gelijk in de ui
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uIManager.buildingInfoHolder.SetActive(false);
    }
}
