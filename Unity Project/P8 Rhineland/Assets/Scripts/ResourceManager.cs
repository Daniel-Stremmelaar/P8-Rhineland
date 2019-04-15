using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public int wood;
    public Text text;

    private void Start()
    {
        text.text = "Wood: " + wood.ToString();
    }

    public void UpdateUI()
    {
        text.text = "Wood: " + wood.ToString();
    }
}
