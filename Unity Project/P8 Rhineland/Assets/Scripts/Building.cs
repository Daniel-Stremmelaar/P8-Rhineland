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
    private Collider c;
    private Gatherer g;
    public int hp;
    public float time;
    public float timeReset;
    public Gatherer spawn;

    [Header("Resources")]
    public ResourceManager r;
    public List<ResourceType> creates = new List<ResourceType>();

    void Start()
    {
        r = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
        builder = GameObject.FindGameObjectWithTag("Builder").GetComponent<Builder>();
        c = GetComponent<Collider>();
        hp = type.hp;
        timeReset = type.timeReset;
        foreach(ResourceType r in type.creates)
        {
            creates.Add(r);
        }
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

            foreach(ResourceType resource in creates)
            {
                if(r.Check(resource.required.index, resource.required.amountNeeded))
                {
                    r.Spend(resource.required.index, resource.required.amountNeeded);
                    r.Gain(resource.index, 1);
                }
            }
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
            if (Input.GetButtonDown("Fire1") && placeable == true && r.Check(0, type.woodCost) && r.Check(2, type.stoneCost) && r.Check(1, type.plankCost) && r.Check(12, type.ironCost))
            {
                placing = false;
                //c.enabled = true;
                c.isTrigger = false;
                gameObject.GetComponent<Renderer>().material = type.material;
                r.Spend(0, type.woodCost);
                r.Spend(2, type.stoneCost);
                r.Spend(1, type.plankCost);
                r.Spend(12, type.ironCost);
                GetComponent<BoxCollider>().size = type.colliderSize;
                Destroy(GetComponent<Rigidbody>());
                if(type.indexes.Count > 0)
                {
                    foreach(int i in type.indexes)
                    {
                        r.resourceCaps[i] += type.amount;
                        r.UpdateUI();
                    }
                }
            }
            if (Input.GetButtonDown("Fire2"))
            {
                Destroy(gameObject);
            }
        }
    }

    public void Upgrade(UIManager u)
    {
        if (type.upgrade != null)
        {
            GameObject g = Instantiate(type.upgrade.building, transform.position, Quaternion.identity);
            g.GetComponent<Building>().type = type.upgrade;
            g.GetComponent<BoxCollider>().size = type.upgrade.colliderSize;
            g.GetComponent<MeshRenderer>().material = type.upgrade.material;

            u.selected = g;
            u.SelectedPanel(g);
            Destroy(this.gameObject);
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
        if(!r.Check(0, type.woodCost) || !r.Check(2, type.stoneCost) || !r.Check(1, type.plankCost) || !r.Check(12, type.ironCost))
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

    public void Recruit()
    {
        if( r.Check(13, type.spawnType.goldCost) && r.CheckCap(15, 1))
        {
            g = Instantiate(spawn, gameObject.transform.position + type.spawnOffset, Quaternion.identity);
            g.type = type.spawnType;
            g.tag = "Gatherer";
            r.Spend(13, type.spawnType.goldCost);
            r.resourcesCurrent[15] += 1;
        }
    }

    public void Maintain(int i)
    {
        if(r.Check(13, i))
        {
            r.Spend(13, i);
        }
        else
        {
            hp -= 1;
            if (hp <= 0)
            {
                Debug.Log("Destroyed  " + gameObject.name);
                Destroy(gameObject);
            }
        }
    }

    public void Repair(BuildingType t)
    {
        if( r.Check(0, t.woodCost/10) && r.Check(2, type.stoneCost/10) && r.Check(1, type.plankCost/10) && r.Check(12, type.ironCost / 10))
        {
            hp = type.hp;
        }
    }

    public void Sell(BuildingType t)
    {
        if(r.CheckCap(0, type.woodCost / 10 * 3) && r.CheckCap(2, type.stoneCost / 10 * 3) && r.CheckCap(1, type.plankCost / 10 * 3) && r.CheckCap(12, type.ironCost / 10 * 3))
        r.Gain(0, type.woodCost / 10 * 3);
        r.Gain(2, type.stoneCost / 10 * 3);
        r.Gain(1, type.plankCost / 10 * 3);
        r.Gain(12, type.ironCost/10 * 3);

        if (type.indexes.Count > 0)
        {
            foreach (int i in type.indexes)
            {
                r.resourceCaps[i] -= type.amount;
                r.UpdateUI();
            }
        }

        Destroy(gameObject);
    }
}
