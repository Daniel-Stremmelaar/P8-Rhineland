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
    public GathererType spawnType;
    public Vector3 spawnOffset;
    public GameObject building;
    public Material material;
    public enum recieves { Wood, Stone, Berry, GoldOre, IronOre, All, None };
    public recieves recieveType;
    public BuildingType upgrade;
    public Vector3 colliderSize;
    public float maintainTime;
    public float createTime;
    public float townHallradius;
    public BuildingType required;
    public GameObject healthBarHolder;
    public Vector3 heathbarSpawnOfzet;

    [Header("Sound")]
    public AudioClip buildingSound;
    public AudioSource buildingSourceSound;

    [Header("Creates")]
    public List<ResourceType> creates = new List<ResourceType>();

    [Header("Stores")]
    public List<int> indexes = new List<int>();
    public int amount;
}
