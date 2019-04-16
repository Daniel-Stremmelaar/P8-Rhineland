using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Building Data", order = 51)]
public class BuildingType : ScriptableObject
{
    public int woodCost;
    public int stoneCost;
}
