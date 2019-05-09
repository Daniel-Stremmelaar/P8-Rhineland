using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    [Header("Resources Current")]
    public int wood;
    public int planks;
    public int stone;
    public int food;
    public int wheat;
    public int flour;
    public int bread;
    public int berry;
    public int wine;
    public int fish;
    public int ironOre;
    public int goldOre;
    public int iron;
    public int gold;
    public int happiness;
    public int popualtion;

    [Header("Resources Caps")]
    public int woodCap;
    public int planksCap;
    public int stoneCap;
    public int foodCap;
    public int wheatCap;
    public int flourCap;
    public int breadCap;
    public int berryCap;
    public int wineCap;
    public int fishCap;
    public int ironOreCap;
    public int goldOreCap;
    public int ironCap;
    public int goldCap;
    public int happinessMax;
    public int happinessMin;
    public int popCap;

    [Header("Resources Text")]
    public Text woodText;
    public Text planksText;
    public Text stoneText;
    public Text foodText;
    public Text wheatText;
    public Text flourText;
    public Text breadText;
    public Text berryText;
    public Text wineText;
    public Text fishText;
    public Text ironOreText;
    public Text goldOreText;
    public Text ironText;
    public Text goldText;
    public Text happinessText;
    public Text popualtionText;

    [Header("Food Count")]
    public int wheatValue;
    public int flourValue;
    public int breadValue;
    public int berryValue;
    public int wineValue;
    public int fishValue;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        food = (wheat * wheatValue) + (flour * flourValue) + (bread * breadValue) + (berry * berryValue) + (wine * wineValue) + (fish * fishValue);
        foodCap = (wheatCap * wheatValue) + (flourCap * flourValue) + (breadCap * breadValue) + (berryCap * berryValue) + (wineCap * wineValue) + (fishCap * fishValue);

        woodText.text = "Wood: " + wood.ToString() + "/" + woodCap.ToString();
        planksText.text = "Planks: " + planks.ToString() + "/" + planksCap.ToString();
        stoneText.text = "Stone: " + stone.ToString() + "/" + stoneCap.ToString();
        foodText.text = "Food: " + food.ToString() + "/" + foodCap.ToString();
        wheatText.text = "Wheat: " + wheat.ToString() + "/" + wheatCap.ToString();
        flourText.text = "Flour: " + flour.ToString() + "/" + flourCap.ToString();
        breadText.text = "Bread: " + bread.ToString() + "/" + breadCap.ToString();
        berryText.text = "Berry: " + berry.ToString() + "/" + berryCap.ToString();
        wineText.text = "Wine: " + wine.ToString() + "/" + wineCap.ToString();
        fishText.text = "Fish: " + fish.ToString() + "/" + fishCap.ToString();
        ironOreText.text = "IronOre: " + ironOre.ToString() + "/" + ironOreCap.ToString();
        goldOreText.text = "GoldOre: " + goldOre.ToString() + "/" + goldOreCap.ToString();
        ironText.text = "IronOre: " + iron.ToString() + "/" + ironCap.ToString();
        goldText.text = "Gold: " + gold.ToString() + "/" + goldCap.ToString();
        happinessText.text = "Happiness: " + happiness.ToString();
        popualtionText.text = "Popualtion: " + popualtion.ToString() + "/" + popCap.ToString();
    }

    public void Spend(string s, int i)
    {
        if(s == "Wood")
        {
            wood -= i;
        }
        if(s == "Planks")
        {
            planks -= i;
        }
        if (s == "Stone")
        {
            stone -= i;
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

        UpdateUI();
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
        else if (s == "Planks")
        {
            if (i <= planks)
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

    // Add spending and checking food
}
