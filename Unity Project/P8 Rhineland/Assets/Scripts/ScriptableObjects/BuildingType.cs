using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Building Data", order = 51)]
public class BuildingType : ScriptableObject
{
    [Header("Costs")]
    public int woodCost;
    public int stoneCost;
    public int plankCost;
    public int ironCost;
    public int maintainCost;

    [Header("Data")]
    public int hp;
    public Gatherer spawnType;
    public Vector3 spawnOffset;
    public Material material;
    public enum recieves { wood, stone, food, gold, all, none };
    public recieves recieveType;

    public void Sell(GameObject g)
    {
        Destroy(g);
    }
}
