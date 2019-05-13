using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [Header("Info")]
    public BuildingType type;

    [Header("Placing")]
    private RaycastHit hit;
    private List<GameObject> colliding = new List<GameObject>();
    public bool placing;
    private bool placeable;

    [Header("Data")]
    private Builder builder;
    public ResourceManager r;
    private Collider c;
    public int hp;
    public float time;
    public float timeReset;

    void Start()
    {
        r = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
        builder = GameObject.FindGameObjectWithTag("Builder").GetComponent<Builder>();
        c = GetComponent<Collider>();
    }

    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }

        if(time <= 0)
        {
            Maintain(type.maintainCost);
            time = timeReset;
        }
        time -= Time.deltaTime;

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
            if (Input.GetButtonDown("Fire1") && placeable == true && r.Check("Wood", type.woodCost) && r.Check("Stone", type.stoneCost) && r.Check("Planks", type.plankCost) && r.Check("Iron", type.ironCost))
            {
                placing = false;
                //c.enabled = true;
                c.isTrigger = false;
                gameObject.GetComponent<Renderer>().material = type.material;
                r.Spend("Wood", type.woodCost);
                r.Spend("Stone", type.stoneCost);
                r.Spend("Planks", type.plankCost);
                r.Spend("Iron", type.ironCost);
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
        if( r.Check("Gold", type.spawnType.type.goldCost) )
        {
            Instantiate(g, gameObject.transform.position + type.spawnOffset, Quaternion.identity);
            r.Spend("Gold", type.spawnType.type.goldCost);
        }
    }

    public void Maintain(int i)
    {
        if(r.Check("Gold", i))
        {
            r.Spend("Gold", i);
        }
        else
        {
            hp -= 1;
        }
    }

    public void Repair(BuildingType t)
    {
        if( r.Check("Wood", t.woodCost/10) && r.Check("Stone", type.stoneCost/10) && r.Check("Planks", type.plankCost/10) && r.Check("Iron", type.ironCost / 10))
        {
            hp = type.hp;
        }
    }

    public void Sell(BuildingType t)
    {
        r.Gain("Wood", type.woodCost / 10 * 3);
        r.Gain("Stone", type.stoneCost / 10 * 3);
        r.Gain("Planks", type.plankCost / 10 * 3);
        r.Gain("Iron", type.ironCost/10 * 3);

        Destroy(gameObject);
    }
}
