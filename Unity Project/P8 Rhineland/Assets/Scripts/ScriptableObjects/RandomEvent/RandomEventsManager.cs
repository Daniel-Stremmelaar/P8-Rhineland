using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//select an event
public class RandomEventsManager : MonoBehaviour
{
    public List<RandomEventScriptableObject> events = new List<RandomEventScriptableObject>();

    bool mayDoRandom = true;
    public int minTimer;
    public int maxTimer;
    public float timer;

    void Start()
    {
        
    }

    void Update()
    {
        if (mayDoRandom == true)
        {
            timer = Random.Range(minTimer, maxTimer);
            StartCoroutine(RandomTimer(timer));
            mayDoRandom = false;
        }
    }

    IEnumerator RandomTimer(float f)
    {
        yield return new WaitForSeconds(f);
        
        int t = Random.Range(0, events.Count);
        RandomEventScriptableObject refe = events[t];

        foreach (RandomEventScriptableObject.AddSlot type in refe.addValues)
        {
            int addValue = type.add ? type.amount : -type.amount;

            switch (type.material)
            {
                case RandomEventScriptableObject.MaterialType.Stone:
                    //add or remove
                    break;
                case RandomEventScriptableObject.MaterialType.Wood:
                    //add or remove
                    break;
                case RandomEventScriptableObject.MaterialType.Planks:
                    //add or remove
                    break;
                case RandomEventScriptableObject.MaterialType.IronOre:
                    //add or remove
                    break;
                case RandomEventScriptableObject.MaterialType.GoldOre:
                    //add or remove
                    break;
                case RandomEventScriptableObject.MaterialType.Iron:
                    //add or remove
                    break;
                case RandomEventScriptableObject.MaterialType.Gold:
                    //add or remove
                    break;
                case RandomEventScriptableObject.MaterialType.Wheat:
                    //add or remove
                    break;
                case RandomEventScriptableObject.MaterialType.Flour:
                    //add or remove
                    break;
                case RandomEventScriptableObject.MaterialType.Bread:
                    //add or remove
                    break;
                case RandomEventScriptableObject.MaterialType.Berry:
                    //add or remove
                    break;
                case RandomEventScriptableObject.MaterialType.Happiness:
                    //add or remove
                    break;
                case RandomEventScriptableObject.MaterialType.Population:
                    //add or remove
                    break;
            }
        }
        mayDoRandom = true;
    }
}