using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Types")]
    public GameObject buildingPanel;
    public GameObject villagerPanel;

    [Header("Building Panel Elements")]
    public Button hire;
    public Button repair;
    public Button sell;

    [Header("Data")]
    public GameObject selected;
    // Start is called before the first frame update
    void Start()
    {
        /*hire.onClick.AddListener(delegate { Hire(selected.GetComponent<Building>()); });
        repair.onClick.AddListener(delegate { Repair(selected.GetComponent<Building>()); });
        sell.onClick.AddListener(delegate { Sell(selected.GetComponent<Building>()); });*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hire(Building b)
    {
        b.Recruit(b.type.spawnType);
    }

    public void Repair(Building b)
    {
        b.Repair(b.type);
    }

    public void Sell(Building b)
    {

    }
}
