using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public OnMouseOverFood onMouseOverFood;
    public GameObject buildingInfoHolder;
    public GameObject hoverOverResource;

    [Header("Building Select")]
    public Text type;
    public Button recruit;
    public Button upgrade;
    public GameObject selectedPanel;
    public GameObject extraFoodUi;
    public GameObject goldOreUi;
    public GameObject ironOreUi;

    [Header("Game Management")]
    public Button speed1;
    public Button speed2;
    public Button speed3;
    public int fast;
    public int superFast;
    public Button reset;
    // Start is called before the first frame update
    void Start()
    {
        CoppleDropDown();
        gatherInfoPanel.SetActive(false);

        escHolder.SetActive(false);
        escOptionsHolder.SetActive(false);
        goldOreUi.SetActive(false);
        ironOreUi.SetActive(false);
        /*
        speed1.onClick.AddListener(delegate { Time.timeScale = 1; });
        speed2.onClick.AddListener(delegate { Time.timeScale = fast; });
        speed3.onClick.AddListener(delegate { Time.timeScale = superFast; });
        */    
        ///
        buttons[0].onClick.AddListener(delegate { OpenPanel(panels[0]); });
        buttons[1].onClick.AddListener(delegate { OpenPanel(panels[1]); });
        buttons[2].onClick.AddListener(delegate { OpenPanel(panels[2]); });
        buttons[3].onClick.AddListener(delegate { OpenPanel(panels[3]); });
        ///
        recruit.onClick.AddListener(Recruit);
        upgrade.onClick.AddListener(Upgrade);
        sell.onClick.AddListener(delegate { Sell(selected.GetComponent<Building>()); });
        repair.onClick.AddListener(delegate { Repair(selected.GetComponent<Building>()); });
        extraFoodUi.SetActive(false);
        ///
        buildingInfoHolder.SetActive(false);
        onMouseOverFood.foodUiHolder.SetActive(false);
        hoverOverResource.SetActive(false);
        reset.onClick.AddListener(ResetGame);
    }

    // Update is called once per frame
    void Update()
    {
        OpenEscMenu();
        hoverOverResource.transform.position = Input.mousePosition;
    }

    public void Repair(Building b)
    {
        b.Repair(b.type);
    }

    public void Sell(Building b)
    {
        b.Sell(b.type);
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
                item.GetComponent<MeshFilter>().mesh = jobsList[i].mesh;
                item.GetComponent<Renderer>().material = jobsList[i].mat;
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
        selected.GetComponent<Building>().Upgrade(gameObject.GetComponent<UIManager>());
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
    //foodui
    public void OpenAndCloseExtraFoodUi(bool b)
    {
        extraFoodUi.SetActive(b);
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(1);
    }
}
