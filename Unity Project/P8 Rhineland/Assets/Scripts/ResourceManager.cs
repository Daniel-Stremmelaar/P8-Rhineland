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

    [Header("Eating")]
    public List<int> foods = new List<int>();
    public List<ResourceType> foodsValues = new List<ResourceType>();

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
            //Update happiness UI
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

            //Update food UI
            average = 0;
            count = 0;
            foreach(int i in foods)
            {
                average += i * foodsValues[count].quantity;
                count++;
            }
            average /= count;
            average = Mathf.RoundToInt(average);
            resourceTexts[3].text = "Food: " + average.ToString();

            time = timer;
        }
    }

    public void UpdateUI()
    {
        index = 0;
        foreach(Text t in resourceTexts)
        {
            if (t != null)
            {
                if (index == 14 || index == 3)
                {
                    index++;
                }
                if (resourceCaps[index] > 0)
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

    public int Eat(int hunger)
    {
        int i = 0;
        for(i = hunger; i > 0; i = i)
        {
            for(int n = 0; n < foods.Count+1; n = n)
            {
                if(foods[n] == 0)
                {
                    n++;
                }
                else
                {
                    foods[n]--;
                    i -= foodsValues[n].quantity;
                }
                if(i <= 0)
                {
                    i = 0;
                    return i;
                }
            }
            return i;
        }
        if (i <= 0)
        {
            i = 0;
        }
        return i;
    }
}
