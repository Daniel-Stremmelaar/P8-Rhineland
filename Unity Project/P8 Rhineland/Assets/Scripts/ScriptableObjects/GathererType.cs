using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gatherer", menuName = "Gatherer Data", order = 51)]
public class GathererType : ScriptableObject
{
    public enum resources { Wood };
    public resources resource;

    [Header("Gathering")]
    public int carryCap;
    public int gatherRange;
    public float gatherTime;
    
    public void Deliver(int i, GameObject g)
    {
        if(i > 0)
        {
            Debug.Log("Delivered " + i.ToString() + " " + resource.ToString());
            switch (resource)
            {
                case resources.Wood:
                    g.GetComponent<DeliverPoint>().r.wood += i;
                    break;
            }
            g.GetComponent<DeliverPoint>().r.UpdateUI();
        }
    }
}
