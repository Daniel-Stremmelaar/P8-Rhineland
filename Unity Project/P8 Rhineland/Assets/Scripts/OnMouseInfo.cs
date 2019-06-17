using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseInfo : MonoBehaviour
{
    public GameObject buildingInfoHolder;

    private void Start()
    {
        buildingInfoHolder.SetActive(false);
    }

    private void OnMouseEnter()
    {
        Debug.Log("KANKER CHINEES");
        buildingInfoHolder.SetActive(true);
    }

    private void OnMouseExit()
    {
        buildingInfoHolder.SetActive(false);
    }
}
