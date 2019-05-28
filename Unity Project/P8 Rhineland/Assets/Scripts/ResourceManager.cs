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
            if (count > 0)
            {
                average /= count;
                average = Mathf.RoundToInt(average);
                resourceTexts[14].text = "Happiness: " + average.ToString();
            }
            else
            {
                print("Divide by 0");
            }

            //Update food UI
            average = 0;
            count = 0;
            foreach(int i in foods)
            {
                average += i * foodsValues[count].quantity;
                count++;
            }
            if (count > 0)
            {
                average /= count;
                average = Mathf.RoundToInt(average);
                resourceTexts[3].text = "Food: " + average.ToString();
            }
            else
            {
                print("Divide by 0");
            }

            time = timer;
        }
    }

    //Fix bug: shows food resources instead of wanted resources
    public void UpdateUI()
    {
        resourceTexts[0].text = resourceTypes[0].name + ": " + resourcesCurrent[0].ToString() + "/" + resourceCaps[0].ToString();
        resourceTexts[1].text = resourceTypes[1].name + ": " + resourcesCurrent[1].ToString() + "/" + resourceCaps[1].ToString();
        resourceTexts[2].text = resourceTypes[2].name + ": " + resourcesCurrent[2].ToString() + "/" + resourceCaps[2].ToString();
        resourceTexts[4].text = resourceTypes[12].name + ": " + resourcesCurrent[12].ToString() + "/" + resourceCaps[12].ToString();
        resourceTexts[5].text = resourceTypes[13].name + ": " + resourcesCurrent[13].ToString() + "/" + resourceCaps[13].ToString();
        resourceTexts[7].text = resourceTypes[15].name + ": " + resourcesCurrent[15].ToString() + "/" + resourceCaps[15].ToString();
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

    public bool CheckCap(int index, int i)
    {
        if(resourceCaps[index] - resourcesCurrent[index] >= i)
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
