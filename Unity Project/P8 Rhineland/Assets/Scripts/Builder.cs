using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
    [Header("Building")]
    public Building b;
    private Building holder;
    public List<BuildingType> buildings = new List<BuildingType>();
    public List<Button> buttons = new List<Button>();
    public Material green;
    public Material red;
    public List<GameObject> townHallList = new List<GameObject>();

    [Header("Locks")]
    public List<GameObject> built = new List<GameObject>();
    public List<bool> mayBuild = new List<bool>();

    void Start()
    {
        buttons[0].onClick.AddListener(delegate { Build(0); });
        buttons[1].onClick.AddListener(delegate { Build(1); });
        buttons[2].onClick.AddListener(delegate { Build(2); });
        buttons[3].onClick.AddListener(delegate { Build(3); });
        buttons[4].onClick.AddListener(delegate { Build(4); });
        buttons[5].onClick.AddListener(delegate { Build(5); });
        buttons[6].onClick.AddListener(delegate { Build(6); });
        buttons[7].onClick.AddListener(delegate { Build(7); });
        buttons[8].onClick.AddListener(delegate { Build(8); });
        buttons[9].onClick.AddListener(delegate { Build(9); });
        buttons[10].onClick.AddListener(delegate { Build(10); });
        buttons[11].onClick.AddListener(delegate { Build(11); });
        buttons[12].onClick.AddListener(delegate { Build(12); });
        buttons[13].onClick.AddListener(delegate { Build(13); });
        buttons[14].onClick.AddListener(delegate { Build(14); });
    }

    private void Update()
    {
        for (int i = 0; i<mayBuild.Count; i++)
        {
            mayBuild[i] = false;
        }
        for (int i = 0; i < buildings.Count; i++)
        {
            foreach(GameObject g in built)
            {
                if (g.GetComponent<Building>().type == buildings[i].required && mayBuild[i] == false)
                {
                    mayBuild[i] = true;
                }
                else if (buildings [i].required == null && mayBuild[i] == false)
                {
                    mayBuild[i] = true;
                }
            }
        }
    }

    public void Build(int i)
    {
        if(buildings[i] != null && mayBuild[i] == true)
        {
            holder = Instantiate(buildings[i].building, Camera.main.ScreenToViewportPoint(Input.mousePosition), Quaternion.identity).GetComponent<Building>();
            holder.placing = true;
            holder.type = buildings[i];
        }
    }
}
