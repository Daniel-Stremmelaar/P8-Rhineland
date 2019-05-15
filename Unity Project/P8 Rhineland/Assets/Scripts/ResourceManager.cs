using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    [Header("Tracking")]
    public List<ResourceType> resourceTypes = new List<ResourceType>();
    public List<int> resourcesCurrent = new List<int>();
    public List<int> resourceCaps = new List<int>();
    public List<Text> resourceTexts = new List<Text>();
    public List<Gatherer> villagers = new List<Gatherer>();

    [Header("Food Values")]
    public int wheatValue;
    public int flourValue;
    public int breadValue;
    public int berryValue;
    public int wineValue;
    public int fishValue;

    [Header("Data")]
    public float time;
    public float timer;
    private int average;
    private int count;
    public int index;

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Gain(0, 100);
            Gain(1, 100);
            Gain(2, 100);
            Gain(12, 100);
        }

        time -= Time.deltaTime;
        if (time <= 0)
        {
            average = 0;
            count = 0;
            foreach(Gatherer g in villagers)
            {
                average += g.happiness;
                count++;
            }
            average /= count;
            average = Mathf.RoundToInt(average);
            resourceTexts[14].text = "Happiness: " + average.ToString();
            time = timer;
        }
    }

    public void UpdateUI()
    {
        index = 0;
        foreach(Text t in resourceTexts)
        {
            if(index == 14)
            {
                index++;
            }
            if(resourceCaps[index] > 0)
            {
                t.text = resourceTypes[index].name + ": " + resourcesCurrent[index].ToString() + "/" + resourceCaps[index].ToString();
            }
            else
            {
                t.text = resourceTypes[index].name + ": " + resourcesCurrent[index];
            }
            index++;
        }
    }

    public void Spend(int index, int i)
    {
        resourcesCurrent[index] -= i;

        UpdateUI();
    }

    public void Gain(int index, int i)
    {
        resourcesCurrent[index] += i;

        UpdateUI();
    }

    public bool Check(int index, int i)
    {
        if(resourcesCurrent[index] >= i)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Add spending and checking food
}
