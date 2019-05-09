using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public int wood;
    public int stone;
    public int weed;
    public int flower;
    public int bread;
    public int ironOre;
    public int goldOre;
    public int iron;
    public int gold;
    public int happiness;
    public int popualtion;
    public int popCap;

    public Text woodText;
    public Text stoneText;

    public Text weedText;
    public Text flowerText;
    public Text breadText;

    public Text ironOreText;
    public Text goldOreText;

    public Text ironText;
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

        weedText.text = "Weed: " + weed.ToString();
        flowerText.text = "Flower: " + flower.ToString();
        breadText.text = "Bread: " + bread.ToString();

        ironOreText.text = "IronOre: " + ironOre.ToString();
        goldOreText.text = "GoldOre: " + goldOre.ToString();
        ironText.text = "IronOre: " + iron.ToString();
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
        if (s == "Weed")
        {
            weed -= i;
        }
        if (s == "Flower")
        {
            flower -= i;
        }
        if (s == "Bread")
        {
            bread -= i;
        }
        if (s == "IronOre")
        {
            ironOre -= i;
        }
        if (s == "GoldOre")
        {
            goldOre -= i;
        }
        if (s == "Iron")
        {
            iron -= i;
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
        else if (s == "Weed")
        {
            if (i <= weed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (s == "Flower")
        {
            if (i <= flower)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (s == "Bread")
        {
            if (i <= bread)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (s == "IronOre")
        {
            if (i <= ironOre)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (s == "GoldOre")
        {
            if (i <= goldOre)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (s == "Iron")
        {
            if (i <= iron)
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
