using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    [Header("Starting Resources")]
    public int wood;
    public int stone;
    public int planks;
    public int iron;
    public int gold;
    public int wheat;
    public int flour;
    public int bread;
    public int berry;
    public int storeCap;

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
    private int total;
    private int count;
    public int index;
    private Builder builder;

    private void Start()
    {
        foods.Add(resourcesCurrent[4]);
        foods.Add(resourcesCurrent[5]);
        foods.Add(resourcesCurrent[6]);
        foods.Add(resourcesCurrent[7]);

        foodsValues.Add(resourceTypes[4]);
        foodsValues.Add(resourceTypes[5]);
        foodsValues.Add(resourceTypes[6]);
        foodsValues.Add(resourceTypes[7]);
        
        builder = GameObject.FindGameObjectWithTag("Builder").GetComponent<Builder>();
        Gain(0, wood);
        Gain(1, planks);
        Gain(2, stone);
        Gain(4, wheat);
        Gain(5, flour);
        Gain(6, bread);
        Gain(7, berry);
        Gain(12, iron);
        Gain(13, gold);
        for (int i = 0; i < resourceCaps.Count; i++)
        {
            resourceCaps[i] = storeCap;
        }
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
        if (Input.GetKeyDown(KeyCode.O))
        {
            Gain(13, 100);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Gain(4, 100);
            Gain(7, 100);
            UpdateFoodUI();
        }

        time -= Time.deltaTime;
        if (time <= 0)
        {
            //Update happiness UI
            average = 0;
            count = 0;
            foreach (Gatherer g in villagers)
            {
                average += g.happiness;
                count++;
            }
            if (count > 0)
            {
                average /= count;
                average = Mathf.RoundToInt(average);
                resourceTexts[8].text = average.ToString();
            }
            else
            {
                //print("Divide by 0");
            }

            time = timer;
        }
    }

    //Fix bug: shows food resources instead of wanted resources
    public void UpdateUI()
    {
        resourceTexts[0].text = resourcesCurrent[0].ToString() + "/" + resourceCaps[0].ToString();
        resourceTexts[1].text = resourcesCurrent[1].ToString() + "/" + resourceCaps[1].ToString();
        resourceTexts[2].text = resourcesCurrent[2].ToString() + "/" + resourceCaps[2].ToString();
        resourceTexts[4].text = resourcesCurrent[12].ToString() + "/" + resourceCaps[12].ToString();
        resourceTexts[5].text = resourcesCurrent[13].ToString() + "/" + resourceCaps[13].ToString();
        resourceTexts[7].text = resourcesCurrent[15].ToString() + "/" + resourceCaps[15].ToString();

        resourceTexts[9].text = resourcesCurrent[7].ToString() + "/" + resourceCaps[7].ToString();
        resourceTexts[10].text = resourcesCurrent[4].ToString() + "/" + resourceCaps[4].ToString();
        resourceTexts[11].text = resourcesCurrent[5].ToString() + "/" + resourceCaps[5].ToString();
        resourceTexts[12].text = resourcesCurrent[6].ToString() + "/" + resourceCaps[6].ToString();
        resourceTexts[13].text = resourcesCurrent[10].ToString() + "/" + resourceCaps[10].ToString();
        resourceTexts[14].text = resourcesCurrent[11].ToString() + "/" + resourceCaps[11].ToString();
    }

    public void UpdateFoodUI()
    {
        total = 0;
        foods[0] = resourcesCurrent[4];
        total+= foods[0] * foodsValues[0].quantity;
        foods[1] = resourcesCurrent[5];
        total+= foods[1] * foodsValues[1].quantity;
        foods[2] = resourcesCurrent[6];
        total+= foods[2] * foodsValues[2].quantity;
        foods[3] = resourcesCurrent[7];
        total+= foods[3] * foodsValues[3].quantity;

        resourceTexts[3].text = total.ToString();
    }

    public void Spend(int index, int i)
    {
        resourcesCurrent[index] -= i;

        UpdateUI();
        builder.CheckBuildable();
        if (index == 4 || index == 5 || index == 6 || index == 7)
        {
            UpdateFoodUI();
        }
    }

    public void Gain(int index, int i)
    {
        resourcesCurrent[index] += i;

        UpdateUI();
        builder.CheckBuildable();
        if(index == 4 || index == 5 || index == 6 || index == 7)
        {
            UpdateFoodUI();
        }
    }

    public bool Check(int index, int i)
    {
        if (resourcesCurrent[index] >= i)
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
        if (resourceCaps[index] - resourcesCurrent[index] >= i)
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
        for (i = hunger; i > 0; i = i)
        {
            for (int n = 0; n < foods.Count + 1; n = n)
            {
                if (foods[n] == 0)
                {
                    n++;
                }
                else
                {
                    foods[n]--;
                    i -= foodsValues[n].quantity;
                }
                if (i <= 0)
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
