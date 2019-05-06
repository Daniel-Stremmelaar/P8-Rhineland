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
}
