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
        uIManager.hoverOverResource.SetActive(true);

        for (int i = 0; i < resourceManager.resourceTexts.Count; i++)
        {
            if (resourceManager.resourceTexts[i] != null)
            {
                if (transform.GetChild(1).name == resourceManager.resourceTexts[i].name)
                {
                    index = i;
                    break;
                }
            }
        }

        uIManager.hoverOverResource.GetComponentInChildren<Text>().text = resourceManager.resourceTexts[index].name;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uIManager.hoverOverResource.SetActive(false);
    }
}
