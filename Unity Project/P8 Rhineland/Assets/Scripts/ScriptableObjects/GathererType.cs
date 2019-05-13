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

    public int foodMin;
    public int foodMax;
    public int food;
    public int consume;
    public float consumeTimer;
    public float consumeTimerReset;

    public int happiness;
    public int happinessMax;

    public enum resources { Wood, Stone };
    public resources resource;

    public void Deliver(int i, GameObject g)
    {
        if (i > 0)
        {
            Debug.Log("Delivered " + i.ToString() + " " + resource.ToString());
            g.GetComponent<Building>().r.Gain(g.GetComponent<Building>().type.recieveType.ToString(), i);
        }
    }

    public void FoodConsumption()
    {
        Debug.Log(food + " food");
        consumeTimer -= Time.deltaTime;
        if (consumeTimer <= 0)
        {
            if (food > foodMin)
            {
                food -= consume;
            }
            else
            {
                Debug.Log("NO FOOD IN POP");
                //if 0 -- kill pop
            }
            consumeTimer = consumeTimerReset;
        }
    }
}
