using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gatherer : MonoBehaviour
{
    [Header("Behavior")]
    public GathererType type;
    public enum state { search, gather, deliver, eat };
    public state currentJob;

    [Header("Navigation")]
    public int triggerGrow;
    private NavMeshAgent agent;
    private SphereCollider trigger;
    public GameObject target;
    private GameObject home;

    [Header("Gathering")]
    private bool gathering;
    private int gathered;
    public float timer;
    private bool delivering;
    private ResourceManager r;
    private GameObject deliverPoint;

    [Header("Happiness and consumption")]
    public int foodMin;
    public int foodMax;
    public int food;
    public int consume;

    public float happinessTimer;
    public float happinessTimerReset;

    public float consumeTimer;
    public float consumeTimerReset;

    public int happiness;

    float happinessMod;
    float consumeMod;

    [Header("Selection")]
    public bool selected = false;
    UIManager ui;

    // Start is called before the first frame update
    void Start()
    {
        r = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
        delivering = false;
        gathering = true;
        currentJob = state.search;
        agent = GetComponent<NavMeshAgent>();
        trigger = GetComponent<SphereCollider>();

        happinessMod = 0.006f * happiness + 0.7f;
        consumeMod = 2 - happinessMod;

        ui = GameObject.FindWithTag("Builder").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(delivering == true)
        {
            Deliver();
        }
        switch (currentJob)
        {
            case state.search:
                //search behavior
                trigger.radius += triggerGrow;
                if(target != null && home != null)
                {
                    if(gathering == true)
                    {
                        currentJob = state.gather;
                    }
                    else
                    {
                        currentJob = state.deliver;
                    }
                    trigger.radius = type.gatherRange;
                }
                break;

            case state.gather:
                //gather behavior
                agent.destination = target.transform.position;
                break;

            case state.deliver:
                //deliver behavior
                agent.destination = home.transform.position;
                break;

            case state.eat:
                //eat behavior
                break;
        }
        FoodConsumption();
        HappinessInfluence();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == type.resource.ToString())
        {
            target = other.gameObject;
            target.GetComponent<ResourcePoint>().current.Add(this.gameObject.GetComponent<Gatherer>());
        }
        if(other.tag == "Home")
        {
            home = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(currentJob == state.gather && other.gameObject.tag == type.resource.ToString())
        {
            timer += Time.deltaTime;
            if(timer >= type.gatherTime)
            {
                gathered += 1;
                target.GetComponent<ResourcePoint>().amount -= 1;
                if(target.GetComponent<ResourcePoint>().amount == 0)
                {
                    target.GetComponent<ResourcePoint>().Empty();
                }
                timer = 0.0f;
                if(gathered == type.carryCap)
                {
                    gathering = false;
                    home = null;
                    target.GetComponent<ResourcePoint>().current.Remove(this.gameObject.GetComponent<Gatherer>());
                    currentJob = state.search;
                }
            }
        }

        /*if(currentJob == state.deliver && gameObject.tag == "Home")
        {
            type.Deliver(gathered, other.gameObject);
            gathered = 0;
            gathering = true;
            target = null;
            currentJob = state.search;
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Home" && gathered > 0)
        {
            delivering = true;
            deliverPoint = collision.gameObject;
        }
    }

    public void Deliver()
    {
        if(r.CheckCap(type.type, gathered))
        {
            type.Deliver(gathered, deliverPoint);
            gathered = 0;
            target.GetComponent<ResourcePoint>().current.Remove(this.gameObject.GetComponent<Gatherer>());
            gathering = true;
            target = null;
            currentJob = state.search;
            delivering = false;
            deliverPoint = null;
        }
    }

    public void HappinessInfluence()
    {
        happinessTimer -= Time.deltaTime * happinessMod;
        if (happinessTimer <= 0)
        {
            if (happiness >= 0 && happiness <= 30)
            {
                happiness -= 1;
                //Debug.Log("onder 30");
                ///movespeed
            }
            if (happiness >= 31 && happiness <= 60)
            {
                happiness -= 1;
                //Debug.Log("midden");
            }
            happinessTimer = happinessTimerReset;
        }
    }

    public void FoodConsumption()
    {
        consumeTimer -= Time.deltaTime * consumeMod;
        if (consumeTimer <= 0)
        {
            if (food > foodMin)
            {
                food -= 1;
            }
            else
            {
                Debug.Log("NO FOOD IN POP");
                //if 0 -- kill pop
            }
            consumeTimer = consumeTimerReset;
        }
    }

    public void OpenUI()
    {
        if (selected == true)
        {
            ui.OpenUIGatherInfo(type.jobSprite);
            
            //geef gode job door
           // ui.jobDropdown.
            //geef andere stats mee
        }
    }
}
