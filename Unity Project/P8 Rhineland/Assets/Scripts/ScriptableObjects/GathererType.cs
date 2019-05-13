using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gatherer", menuName = "Gatherer Data", order = 51)]
public class GathererType : ScriptableObject
{
    [Header("Gathering")]
    public int carryCap;
    public int gatherRange;
    public float gatherTime;

    [Header("Data")]
    public int goldCost;
    public int consume;
    public enum resources { Wood, Stone };
    public resources resource;

    public void Deliver(int i, GameObject g)
    {
        if(i > 0)
        {
            Debug.Log("Delivered " + i.ToString() + " " + resource.ToString());
            switch (resource)
            {
                case resources.Wood:
                    g.GetComponent<Building>().r.wood += i;
                    break;

                case resources.Stone:
                    g.GetComponent<Building>().r.stone += i;
                    break;
            }
            g.GetComponent<Building>().r.UpdateUI();
        }
    }
}
