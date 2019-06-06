using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHoverOver : MonoBehaviour
{
    public GameObject foodInfo;
    private void Start()
    {
        foodInfo.SetActive(false);
    }

    public void OnMouseOver()
    {
        Debug.Log("HOVER DE HOVER");
        if (tag == "FoodUi")
        {
            foodInfo.SetActive(true);
        }
    }
    public void OnMouseExit()
    {
        foodInfo.SetActive(false);
        Debug.Log("EXIT HOVER EXIT");
    }

}
