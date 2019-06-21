using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverOverSelected : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Scripts")]
    public UIManager uIManager;
    public CamraMove camraMove;

    [Header("UI")]
    public List<Text> texts = new List<Text>();
    public Text recruitCostText;


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.name == "Upgrade")
        {
            uIManager.buildingInfoHolder.SetActive(true);
            texts[0].text = camraMove.selected.GetComponent<Building>().type.upgrade.woodCost.ToString();
            texts[1].text = camraMove.selected.GetComponent<Building>().type.upgrade.stoneCost.ToString();
            texts[2].text = camraMove.selected.GetComponent<Building>().type.upgrade.plankCost.ToString();
            texts[3].text = camraMove.selected.GetComponent<Building>().type.upgrade.ironCost.ToString();
        }
        else if(gameObject.name == "Recruit")
        {
            uIManager.recruitCostTextHolder.SetActive(true);
            recruitCostText.text = camraMove.selected.GetComponent<Building>().type.spawnType.goldCost.ToString();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uIManager.buildingInfoHolder.SetActive(false);
        uIManager.recruitCostTextHolder.SetActive(false);
    }
}
