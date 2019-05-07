using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [Header("Info")]
    public BuildingType type;
    public Material material;

    [Header("Placing")]
    private RaycastHit hit;
    private List<GameObject> colliding = new List<GameObject>();
    public bool placing;
    private bool placeable;

    [Header("Data")]
    public Gatherer spawnType;
    public Vector3 spawnOffset;
    private Builder builder;
    private ResourceManager r;
    private Collider c;

    void Start()
    {
        r = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
        builder = GameObject.FindGameObjectWithTag("Builder").GetComponent<Builder>();
        c = GetComponent<Collider>();
    }

    void Update()
    {
        if(placing == true)
        {
            //c.enabled = false;
            c.isTrigger = true;

            CheckCollision();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                transform.position = hit.point;
            }
            if (Input.GetButtonDown("Fire1") && placeable == true && r.Check("Wood", type.woodCost) && r.Check("Stone", type.stoneCost))
            {
                placing = false;
                //c.enabled = true;
                c.isTrigger = false;
                gameObject.GetComponent<Renderer>().material = material;
            }
            if (Input.GetButtonDown("Fire2"))
            {
                Destroy(gameObject);
            }
        }
    }

    private void CheckCollision()
    {
        placeable = true;
        gameObject.GetComponent<Renderer>().material = builder.green;
        foreach (GameObject g in colliding)
        {
            if(g.tag != "Terrain")
            {
                placeable = false;
                gameObject.GetComponent<Renderer>().material = builder.red;
            }
        }
        if(!r.Check("Wood", type.woodCost) || !r.Check("Stone", type.stoneCost))
        {
            gameObject.GetComponent<Renderer>().material = builder.red;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        colliding.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        colliding.Remove(other.gameObject);
    }

    public void Recruit(Gatherer g)
    {
        if( r.Check("Gold", spawnType.goldCost) )
        {
            Instantiate(g, gameObject.transform.position + spawnOffset, Quaternion.identity);
        }
    }
}
