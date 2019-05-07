using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Building Data", order = 51)]
public class BuildingType : ScriptableObject
{
    public int woodCost;
    public int stoneCost;
    public int maintainCost;
    public enum recieves { wood, stone, food, gold, all, none };
    public recieves recieveType;
    public Gatherer spawnType;
}
