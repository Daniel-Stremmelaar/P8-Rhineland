using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [Header("Info")]
    public BuildingType type;
    CamMoveEmpty camMoveEmpty;

    [Header("Placing")]
    private RaycastHit hit;
    private List<GameObject> colliding = new List<GameObject>();
    public bool placing;
    private bool placeable;

    [Header("Rotate")]
    float rotSpeed = 50f;
    Vector3 rotVector;

    [Header("Data")]
    private Builder builder;
    private Collider c;
    private Gatherer g;
    public int hp;
    public float time;
    public float timeReset;
    public Gatherer spawn;
    public GameObject radiusSprite;

    SoundManager soundManager;
    UIManager u;

    [Header("Resources")]
    public ResourceManager r;
    public List<ResourceType> creates = new List<ResourceType>();

    void Start()
    {
        u = GameObject.FindGameObjectWithTag("Builder").GetComponent<UIManager>();
        r = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
        builder = GameObject.FindGameObjectWithTag("Builder").GetComponent<Builder>();
        c = GetComponent<Collider>();
        hp = type.hp;
        timeReset = type.timeReset;
        foreach (ResourceType r in type.creates)
        {
            creates.Add(r);
        }
        soundManager = GameObject.FindWithTag("Builder").GetComponent<SoundManager>();
        camMoveEmpty = GameObject.FindWithTag("Respawn").GetComponent<CamMoveEmpty>();
        rotVector.y += 1f;
    }

    void Update()
    {
        RotateObject();
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        if (time <= 0)
        {
            Maintain(type.maintainCost);
            time = timeReset;

            foreach (ResourceType resource in creates)
            {
                if (r.Check(resource.required.index, resource.required.amountNeeded))
                {
                    r.Spend(resource.required.index, resource.required.amountNeeded);
                    r.Gain(resource.index, 1);
                }
            }
        }
        time -= Time.deltaTime;

        if (placing == true)
        {
            //c.enabled = false;
            c.isTrigger = true;

            CheckCollision();
            if (gameObject.tag != "TownHall")
            {
                CheckTownHall();
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                transform.position = hit.point;
            }
            if (Input.GetButtonDown("Fire1") && placeable == true && r.Check(0, type.woodCost) && r.Check(2, type.stoneCost) && r.Check(1, type.plankCost) && r.Check(12, type.ironCost))
            {
                placing = false;
                GameObject g = Instantiate(type.buildingSourceSound.gameObject, transform.position, Quaternion.Euler(0,0,0));
                Destroy(g, type.buildingSourceSound.clip.length);
                c.isTrigger = false;
                if (gameObject.tag != "TownHall")
                {
                    gameObject.GetComponent<Renderer>().material = type.material;
                }
                else
                {
                    foreach (Renderer rend in gameObject.GetComponentsInChildren<Renderer>())
                    {
                        rend.material = type.material;
                    }
                }
                r.Spend(0, type.woodCost);
                r.Spend(2, type.stoneCost);
                r.Spend(1, type.plankCost);
                r.Spend(12, type.ironCost);
                GetComponent<BoxCollider>().size = type.colliderSize;
                Destroy(GetComponent<Rigidbody>());
                builder.built.Add(this.gameObject);
                if (type.indexes.Count > 0)
                {
                    foreach (int i in type.indexes)
                    {
                        r.resourceCaps[i] += type.amount;
                        r.UpdateUI();
                    }
                }
                if (gameObject.tag == "TownHall")
                {
                    builder.townHallList.Add(gameObject);
                }
            }
            if (Input.GetButtonDown("Fire2"))
            {
                camMoveEmpty.mayRot = true;
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
            builder.built.Add(g.gameObject);

            u.selected = g;
            u.SelectedPanel(g);
            builder.built.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void CheckCollision()
    {
        placeable = true;
        if (gameObject.tag != "TownHall")
        {
            gameObject.GetComponent<Renderer>().material = builder.green;
        }
        else
        {
            foreach (Renderer rend in gameObject.GetComponentsInChildren<Renderer>())
            {
                rend.material = builder.green;
            }
        }
        foreach (GameObject g in colliding)
        {
            if (g.tag != "Terrain")
            {
                placeable = false;
                if (gameObject.tag != "TownHall")
                {
                    gameObject.GetComponent<Renderer>().material = builder.red;
                }
                else
                {
                    foreach (Renderer rend in gameObject.GetComponentsInChildren<Renderer>())
                    {
                        rend.material = builder.red;
                    }
                }
            }
        }
        if (!r.Check(0, type.woodCost) || !r.Check(2, type.stoneCost) || !r.Check(1, type.plankCost) || !r.Check(12, type.ironCost))
        {
            if (gameObject.tag != "TownHall")
            {
                gameObject.GetComponent<Renderer>().material = builder.red;
            }
            else
            {
                foreach (Renderer rend in gameObject.GetComponentsInChildren<Renderer>())
                {
                    rend.material = builder.red;
                }
            }
        }
    }

    void CheckTownHall()
    {
        foreach (GameObject closeTown in builder.townHallList)
        {
            if (Vector3.Distance(transform.position, closeTown.transform.position) <= closeTown.GetComponent<Building>().type.townHallradius)
            {
                //placeable = true;
                //gameObject.GetComponent<Renderer>().material = builder.green;
                CheckCollision();
                break;
            }
            else
            {
                placeable = false;
                gameObject.GetComponent<Renderer>().material = builder.red;
            }
        }
    }

    void RotateObject()
    {
        if (placing == true)
        {
            camMoveEmpty.mayRot = false;
            if (Input.GetButton("TurnLeft"))
            {
                //rotate left
                transform.Rotate(rotVector * Time.deltaTime * rotSpeed);
                
            }
            if (Input.GetButton("TurnRight"))
            {
                //rotate right
                transform.Rotate(-rotVector * Time.deltaTime * rotSpeed);
            }
        }
        else
        {
            camMoveEmpty.mayRot = true;
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
        if (r.Check(13, type.spawnType.goldCost) && r.CheckCap(15, 1))
        {
            g = Instantiate(spawn, gameObject.transform.position + type.spawnOffset, Quaternion.identity);
            g.type = type.spawnType;
            g.tag = "Gatherer";
            r.Spend(13, type.spawnType.goldCost);
            r.resourcesCurrent[15] += 1;
            r.villagers.Add(g);
        }
    }

    public void Maintain(int i)
    {
        if (r.Check(13, i))
        {
            r.Spend(13, i);
        }
        else
        {
            hp -= 1;
            if (hp <= 0)
            {
                //Debug.Log("Destroyed  " + gameObject.name);
                Destroy(gameObject);
            }
        }
    }

    public void Repair(BuildingType t)
    {
        if (hp < type.hp && r.Check(0, t.woodCost / 10) && r.Check(2, type.stoneCost / 10) && r.Check(1, type.plankCost / 10) && r.Check(12, type.ironCost / 10))
        {
            r.Spend(0, t.woodCost / 10);
            r.Spend(2, type.stoneCost / 10);
            r.Spend(1, type.plankCost / 10);
            r.Spend(12, type.ironCost / 10);
            hp = type.hp;
        }
    }

    public void Sell(BuildingType t)
    {
        if (r.CheckCap(0, type.woodCost / 10 * 3))
        {
            r.Gain(0, type.woodCost / 10 * 3);
        }
        if (r.CheckCap(2, type.stoneCost / 10 * 3))
        {
            r.Gain(2, type.stoneCost / 10 * 3);
        }
        if (r.CheckCap(1, type.plankCost / 10 * 3))
        {
            r.Gain(1, type.plankCost / 10 * 3);
        }
        if (r.CheckCap(12, type.ironCost / 10 * 3))
        {
            r.Gain(12, type.ironCost / 10 * 3);
        }

        if (type.indexes.Count > 0)
        {
            foreach (int i in type.indexes)
            {
                r.resourceCaps[i] -= type.amount;
                r.UpdateUI();
            }
        }
        u.Deselect();
        builder.built.Remove(this.gameObject);
        Destroy(gameObject);
    }
}
