using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    [Header("Resources Current")]
    public int wood;
    public int stone;
    public int wheat;
    public int flour;
    public int bread;
    public int ironOre;
    public int goldOre;
    public int iron;
    public int gold;
    public int happiness;
    public int popualtion;

    [Header("Resources Caps")]
    public int woodCap;
    public int stoneCap;
    public int wheatCap;
    public int flourCap;
    public int breadCap;
    public int ironOreCap;
    public int goldOreCap;
    public int ironCap;
    public int goldCap;
    public int happinessMax;
    public int happinessMin;
    public int popCap;

    [Header("Resources Text")]
    public Text woodText;
    public Text stoneText;
    public Text wheatText;
    public Text flourText;
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

        wheatText.text = "Wheat: " + wheat.ToString();
        flourText.text = "Flour: " + flour.ToString();
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
        if (s == "Wheat")
        {
            wheat -= i;
        }
        if (s == "Flour")
        {
            flour -= i;
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
        else if (s == "Wheat")
        {
            if (i <= wheat)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (s == "Flour")
        {
            if (i <= flour)
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
