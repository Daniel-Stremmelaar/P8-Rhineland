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
    public int type;
    public Sprite jobSprite;

    public enum resources { Wood, Stone, Planks, Berry, IronOre, GoldOre };
    public resources resource;

    public void Deliver(int i, GameObject g)
    {
        if(resource == resources.Wood)
        {
            type = 0;
        }
        if(resource == resources.Stone)
        {
            type = 2;
        }
        if(resource == resources.Planks)
        {
            type = 1;
        }
        if(resource == resources.Berry)
        {
            type = 7;
        }
        if(resource == resources.IronOre)
        {
            type = 10;
        }
        if(resource == resources.GoldOre)
        {
            type = 11;
        }
        if (i > 0)
        {
            Debug.Log("Delivered " + i.ToString() + " " + resource.ToString());
            g.GetComponent<Building>().r.Gain(type, i);
        }
    }
}
