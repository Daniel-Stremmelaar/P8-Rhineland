using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnMouseOverResource : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Scripts")]
    public UIManager uIManager;
    public ResourceManager resourceManager;
    int index;

    public void OnPointerEnter(PointerEventData eventData)
    {
        uIManager.buildingInfoHolder.SetActive(true);

        if (!transform.GetChild(0).GetComponent<Button>())
        {
            transform.GetChild(1);
        }
        else
        {
            for (int i = 0; i < resourceManager.resourceTexts.Count; i++)
            {
                if (transform.GetChild(0).name == resourceManager.resourceTexts[i].name)
                {
                    index = i;
                    break;
                }
            }
            //Text.text = builder.buildings[index].name;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uIManager.buildingInfoHolder.SetActive(false);
    }
}
