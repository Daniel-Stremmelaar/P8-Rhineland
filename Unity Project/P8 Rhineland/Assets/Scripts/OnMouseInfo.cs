﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnMouseInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Scripts")]
    public UIManager uIManager;
    public Builder builder;

    [Header("BuildInfo")]
    public List<Text> texts = new List<Text>();
    int index;

    public void OnPointerEnter(PointerEventData eventData)
    {
        uIManager.buildingInfoHolder.SetActive(true);

            for (int i = 0; i < builder.buttons.Count; i++)
            {
                if (transform.GetChild(0).name == builder.buttons[i].name)
                {
                    index = i;
                    break;
                }
            }
            texts[0].text = builder.buildings[index].name;
            texts[1].text = builder.buildings[index].woodCost.ToString();
            texts[2].text = builder.buildings[index].stoneCost.ToString();
            texts[3].text = builder.buildings[index].plankCost.ToString();
            texts[4].text = builder.buildings[index].ironCost.ToString();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uIManager.buildingInfoHolder.SetActive(false);
    }
}
