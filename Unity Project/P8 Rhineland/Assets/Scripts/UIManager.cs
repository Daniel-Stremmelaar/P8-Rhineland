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
    public Button repair;
    public Button sell;

    [Header("Job")]
    public List<GathererType> jobsList = new List<GathererType>();
    public Dropdown jobDropdown;
    public GameObject gatherInfoPanel;
    public Image gethererImage;

    [Header("Data")]
    public GameObject selected;
    public GameObject escHolder;
    public GameObject escOptionsHolder;

    [Header("Building Select")]
    public Text type;
    public Button recruit;
    public Button upgrade;
    public GameObject selectedPanel;
    // Start is called before the first frame update
    void Start()
    {
        CoppleDropDown();
        gatherInfoPanel.SetActive(false);

        escHolder.SetActive(false);
        escOptionsHolder.SetActive(false);
        Debug.Log("VOORBIJ DE START VAN UIMANAGER VOORBIJ DE START VAN UIMANAGER VOORBIJ DE START VAN UIMANAGER VOORBIJ DE START VAN UIMANAGER ");
        ///
        buttons[0].onClick.AddListener(delegate { OpenPanel(panels[0]); });
        buttons[1].onClick.AddListener(delegate { OpenPanel(panels[1]); });
        buttons[2].onClick.AddListener(delegate { OpenPanel(panels[2]); });
        ///
        recruit.onClick.AddListener(Recruit);
        upgrade.onClick.AddListener(Upgrade);
        /*
        repair.onClick.AddListener(delegate { Repair(selected.GetComponent<Building>()); });
        sell.onClick.AddListener(delegate { Sell(selected.GetComponent<Building>()); });
        */
    }

    // Update is called once per frame
    void Update()
    {
        OpenEscMenu();
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

    //switch job
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

    //building select
    public void OpenPanel(GameObject panel)
    {
        foreach(GameObject g in panels)
        {
            g.SetActive(false);
            panel.SetActive(true);
        }
    }

    public void SelectedPanel(GameObject g)
    {
        selected = g;
        type.text = g.GetComponent<Building>().type.name;
        selectedPanel.SetActive(true);
    }

    //Deselect
    public void Deselect()
    {
        selectedPanel.SetActive(false);
        selected = null;
    }

    public void Recruit()
    {
        selected.GetComponent<Building>().Recruit();
    }

    public void Upgrade()
    {
        selected.GetComponent<Building>().Upgrade();
    }
    
    //Esc menu
    public void OpenEscMenu()
    {
        if (Input.GetButtonDown("Escape"))
        {
            Time.timeScale = 0;
            escHolder.SetActive(true);
        }
    }
    public void OpenOptionsMenu()
    {
        escHolder.SetActive(false);
        escOptionsHolder.SetActive(true);
    }
    public void CloseOptionsMenu()
    {
        escHolder.SetActive(true);
        escOptionsHolder.SetActive(false);
    }
    public void ContinueEscMenu()
    {
        Time.timeScale = 1;
        escHolder.SetActive(false);
    }

    /*
     food and happy niet af
    /// 
    recruit/
    buidling /
    ghatering 
    jobswitch 

    ///
    3 townhals //
    charakter //

     */


}
