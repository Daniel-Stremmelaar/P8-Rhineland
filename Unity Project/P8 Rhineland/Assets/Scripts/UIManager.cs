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

    [Header("Job")]
    public List<GathererType> jobsList = new List<GathererType>();
    public Dropdown jobDropdown;
    public GameObject gatherInfoPanel;
    public Image ghatererPhoto;

    [Header("Data")]
    public GameObject selected;
    // Start is called before the first frame update
    void Start()
    {
        /*hire.onClick.AddListener(delegate { Hire(selected.GetComponent<Building>()); });
        repair.onClick.AddListener(delegate { Repair(selected.GetComponent<Building>()); });
        sell.onClick.AddListener(delegate { Sell(selected.GetComponent<Building>()); });*/
        CoppleDropDown();
        gatherInfoPanel.SetActive(false);
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

    public void OpenUIGatherInfo(Sprite s)
    {
        ghatererPhoto.sprite = s;

        gatherInfoPanel.SetActive(true);
    }

    public void CoppleDropDown()
    {
        List<string> fillName = new List<string>();
        int curPos = 0;
        foreach (var name in jobsList)
        {
            fillName.Add(jobsList[curPos].name);
            curPos += 1;
        }
        jobDropdown.ClearOptions();
        jobDropdown.AddOptions(fillName);
    }
    // copple list job to job gatherer

    /*
    /// als elke gat eigen values heeft open het met de values     
    
    
    public void CoppleDropdownList()
    {
        List<string> fillName = new List<string>();
        foreach (var name in modelList[currIndex].alphasList)
        {
            fillName.Add(name.name);
        }
        foreach (var dropDown in alphaDorpdownList)
        {
            dropDown.ClearOptions();
            dropDown.AddOptions(fillName);
            dropDown.value = 5;
        }
    }
     */
}
