using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resource", menuName = "Resource Data", order = 51)]
public class ResourceType : ScriptableObject
{
    string resourceName;

    public int quantity;

    public ResourceType required;
    public int amountNeeded;

    public int index;
}
