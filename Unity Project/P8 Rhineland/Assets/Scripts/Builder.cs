using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
    public Building b;
    private Building holder;
    public List<BuildingType> buildings = new List<BuildingType>();
    public Button storehouse;
    public Material green;
    public Material red;
    // Start is called before the first frame update
    void Start()
    {
        storehouse.onClick.AddListener(delegate { Build(0); } );
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
