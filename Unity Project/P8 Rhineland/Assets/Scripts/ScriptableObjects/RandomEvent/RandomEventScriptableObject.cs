using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomEvent", menuName = "RandomEvent")]
public class RandomEventScriptableObject : ScriptableObject
{
    public AddSlot[] addValues;

    public enum MaterialType
    {
        Stone,
        Wood,
        Planks,
        IronOre,
        GoldOre,
        Iron,
        Gold,
        Wheat,
        Flour,
        Bread,
        Berry,
        Happiness,
        Population,
    }

    [System.Serializable]
    public class AddSlot
    {
        public string eventName;
        public string description;
        public MaterialType material;
        public int amount;
        public bool add;
    }
}
