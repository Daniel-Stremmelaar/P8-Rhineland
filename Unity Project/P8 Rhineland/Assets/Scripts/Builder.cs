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
    RaycastHit hit;

    [Header("Locks")]
    public List<GameObject> built = new List<GameObject>();
    public List<bool> mayBuild = new List<bool>();
    public ResourceManager r;

    void Start()
    {
        r = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
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

    public void CheckBuildable()
    {
        for (int i = 0; i < mayBuild.Count; i++)
        {
            mayBuild[i] = false;
            buttons[i].interactable = false;
        }
        if (r.Check(0, buildings[9].woodCost) && r.Check(2, buildings[9].stoneCost) && r.Check(1, buildings[9].plankCost) && r.Check(12, buildings[9].ironCost))
        {
            mayBuild[9] = true;
            buttons[9].interactable = true;
        }
        for (int i = 0; i < buildings.Count; i++)
        {
            foreach (GameObject g in built)
            {
                if (buildings[i].required == null && r.Check(0, buildings[i].woodCost) && r.Check(2, buildings[i].stoneCost) && r.Check(1, buildings[i].plankCost) && r.Check(12, buildings[i].ironCost))
                {
                    mayBuild[i] = true;
                    buttons[i].interactable = true;
                }
                else if (g.GetComponent<Building>().type == buildings[i].required && r.Check(0, buildings[i].woodCost) && r.Check(2, buildings[i].stoneCost) && r.Check(1, buildings[i].plankCost) && r.Check(12, buildings[i].ironCost))
                {
                    mayBuild[i] = true;
                    buttons[i].interactable = true;
                }
            }
        }
    }

    public void Build(int i)
    {
        if (buildings[i] != null && mayBuild[i] == true)
        {
            holder = Instantiate(buildings[i].building, Camera.main.ScreenToViewportPoint(Input.mousePosition), Quaternion.LookRotation(hit.normal)).GetComponent<Building>();
            holder.placing = true;
            holder.type = buildings[i];
        }
    }
    void Update()
    {
        if (holder != null)
        {
            if (Physics.Raycast(holder.gameObject.transform.position, Vector3.down, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Terrain")
                {
                    //Vector3 newRot = hit.normal;
                    //float lastY = holder.gameObject.transform.eulerAngles.y;
                    holder.gameObject.transform.rotation = Quaternion.Lerp(holder.gameObject.transform.rotation, Quaternion.FromToRotation(transform.up, hit.normal), Time.deltaTime * 20);
                    //holder.gameObject.transform.eulerAngles = new Vector3(holder.gameObject.transform.eulerAngles.x,lastY,holder.gameObject.transform.eulerAngles.z);
                }
            }
            //Debug.DrawRay(holder.gameObject.transform.position, hit.normal, Color.green, Mathf.Infinity);
        }
    }
}
