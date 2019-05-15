using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomEvent", menuName = "Event")]
public class RandomEventScriptableObject : ScriptableObject
{
    public string eventName;

    public string description;

    public int amount;

    /*
    public void Event()
    {
        Debug.Log(description + amount.ToString());
    }
    */
}
