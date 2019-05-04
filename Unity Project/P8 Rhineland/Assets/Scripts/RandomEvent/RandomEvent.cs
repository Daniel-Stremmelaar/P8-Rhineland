using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvent : MonoBehaviour
{
    public List<RandomEventPlus> randomEventPlus = new List<RandomEventPlus>();
    public List<RandomEventMinus> randomEventMinus = new List<RandomEventMinus>();
    
}

[System.Serializable]
public class RandomEventPlus
{
    public string name;
    public string discription;

    public int plusSomthing;
}

[System.Serializable]
public class RandomEventMinus
{
    public string name;
    public string discription;

    public int minusSomthing;
}