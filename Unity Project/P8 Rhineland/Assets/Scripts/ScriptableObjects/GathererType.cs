using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gatherer", menuName = "Gatherer Data", order = 51)]
public class GathererType : ScriptableObject
{
    [Header("Type")]
    public string resource;

    [Header("Gathering")]
    public int carryCap;
    public int gatherRange;
    public float gatherTime;
    
    public void Deliver(int i)
    {
        if(i > 0)
        {
            Debug.Log("Delivered " + i.ToString() + " " + resource);
        }
    }
}
