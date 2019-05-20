using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Types")]
    public GameObject buildingPanel;
    public GameObject villagerPanel;

    [Header("Panel Management")]
    public List<Button> buttons = new List<Button>();
    public List<GameObject> panels = new List<GameObject>();

    [Header("Building Panel Elements")]
    public Button hire;
    public Button repair;
    public Button sell;

    [Header("Job")]
    public List<GathererType> jobsList = new List<GathererType>();
    public Dropdown jobDropdown;
    public GameObject gatherInfoPanel;
    public Image gethererImage;

    [Header("Data")]
    public GameObject selected;
    // Start is called before the first frame update
    void Start()
    {
        buttons[0].onClick.AddListener(delegate { OpenPanel(panels[0]); });
        buttons[1].onClick.AddListener(delegate { OpenPanel(panels[1]); });
        buttons[2].onClick.AddListener(delegate { OpenPanel(panels[2]); });
        /*
        hire.onClick.AddListener(delegate { Hire(selected.GetComponent<Building>()); });
        repair.onClick.AddListener(delegate { Repair(selected.GetComponent<Building>()); });
        sell.onClick.AddListener(delegate { Sell(selected.GetComponent<Building>()); });
        */
        CoppleDropDown();
        gatherInfoPanel.SetActive(false);
        Debug.Log("DONE THE STARTDONE THE STARTDONE THE STARTDONE THE STARTDONE THE STARTDONE THE STARTDONE THE STARTDONE THE START");
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
        gethererImage.sprite = s;
        gatherInfoPanel.SetActive(true);
    }

    public void ChangeJob(int i)
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Gatherer"))
        {
            if (item.GetComponent<Gatherer>().selected == true)
            {
                item.GetComponent<Gatherer>().type = jobsList[i];
                gethererImage.sprite = jobsList[i].jobSprite;
            }
        }
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

    public void OpenPanel(GameObject panel)
    {
        foreach(GameObject g in panels)
        {
            g.SetActive(false);
            panel.SetActive(true);
        }
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
