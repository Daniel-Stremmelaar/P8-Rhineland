using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public int wood;
    public int stone;
    public int food;
    public int gold;
    public int happiness;
    public int popualtion;
    public int popCap;

    public Text woodText;
    public Text stoneText;
    public Text foodText;
    public Text goldText;
    public Text happinessText;
    public Text popualtionText;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        woodText.text = "Wood: " + wood.ToString();
        stoneText.text = "Stone: " + stone.ToString();
        foodText.text = "Food: " + food.ToString();
        goldText.text = "Gold: " + gold.ToString();
        happinessText.text = "Happiness: " + happiness.ToString();
        popualtionText.text = "Popualtion: " + popualtion.ToString() + "/" + popCap.ToString();
    }

    public void Spend(string s, int i)
    {
        if(s == "Wood")
        {
            wood -= i;
        }
        if (s == "Stone")
        {
            stone -= i;
        }
        if (s == "Food")
        {
            food -= i;
        }
        if (s == "Gold")
        {
            gold -= i;
        }
    }

    public bool Check(string s, int i)
    {
        if (s == "Wood")
        {
            if(i <= wood)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (s == "Stone")
        {
            if (i <= stone)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (s == "Food")
        {
            if (i <= food)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (s == "Gold")
        {
            if (i <= gold)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
