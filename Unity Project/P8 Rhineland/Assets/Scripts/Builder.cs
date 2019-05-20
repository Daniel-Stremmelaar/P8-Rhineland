using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
    public Building b;
    private Building holder;
    public List<BuildingType> buildings = new List<BuildingType>();
    public List<Button> buttons = new List<Button>();
    public Material green;
    public Material red;

    void Start()
    {
        int i = 0;
        foreach(Button b in buttons)
        {
            b.onClick.AddListener(delegate { Build(i); } );
            i++;
        }
    }

    public void Build(int i)
    {
        if(buildings[i] != null)
        {
            holder = Instantiate(b, Camera.main.ScreenToViewportPoint(Input.mousePosition), Quaternion.identity);
            holder.placing = true;
            holder.type = buildings[i];
        }
    }
}
