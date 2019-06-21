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
    private bool eating;
    public int foodMin;
    public int foodMax;
    public int food;
    public int eatPoint;
    public int satiated;
    public int starving;
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
    Animator animator;
    UIManager ui;

    // Start is called before the first frame update
    void Start()
    {
        foodMax = type.foodMax;
        foodMin = type.foodMin;
        consume = 0;
        food = foodMax;
        eatPoint = food / 2;
        starving = foodMax / 4;
        satiated = (foodMax / 4) * 3;
        r = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
        delivering = false;
        gathering = true;
        currentJob = state.search;
        agent = GetComponent<NavMeshAgent>();
        trigger = GetComponent<SphereCollider>();

        happinessMod = 0.006f * happiness + 0.7f;
        consumeMod = 2 - happinessMod;

        ui = GameObject.FindWithTag("Builder").GetComponent<UIManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HappinessInfluence();
        FoodConsumption();

        if (delivering == true)
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
                    if(gathering == true && eating == false)
                    {
                        currentJob = state.gather;
                    }
                    else if(gathering == false && eating == false)
                    {
                        currentJob = state.deliver;
                    }
                    else if(eating == true)
                    {
                        currentJob = state.eat;
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
                agent.destination = target.transform.position;
                break;
        }
        Debug.Log(Vector3.Distance(transform.position, target.transform.position));
        if (transform.position != target.transform.position)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == type.resource.ToString() && eating == false)
        {
            target = other.gameObject;
            target.GetComponent<ResourcePoint>().current.Add(this.gameObject.GetComponent<Gatherer>());
        }
        if(other.tag == "Home" || other.tag == "TownHall")
        {
            if(type.resource.ToString() == other.GetComponent<Building>().type.recieveType.ToString() || other.GetComponent<Building>().type.recieveType.ToString() == "All")
            {
                home = other.gameObject;
            }
        }
        if(other.tag == "Tavern" && eating == true)
        {
            target = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(currentJob == state.gather && other.gameObject.tag == type.resource.ToString())
        {
            timer += Time.deltaTime * happinessMod;
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Home" && gathered > 0 || collision.gameObject.tag == "TownHall" && gathered > 0)
        {
            delivering = true;
            deliverPoint = collision.gameObject;
        }
        if(collision.gameObject.tag == "Tavern")
        {
            consume = r.Eat(consume);
            food = foodMax - consume;
            eatPoint = food / 2;
            target = null;
            currentJob = state.search;
            eating = false;
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
        happinessMod = 0.006f * happiness + 0.7f;
        consumeMod = 2 - happinessMod;
    }

    public void FoodConsumption()
    {
        consumeTimer -= Time.deltaTime * consumeMod;
        if (consumeTimer <= 0)
        {
            if (food > foodMin)
            {
                food -= 1;
                consume += 1;
            }
            else if(food < 1)
            {
                Debug.Log("NO FOOD IN POP");
                r.villagers.Remove(this.gameObject.GetComponent<Gatherer>());
                Destroy(gameObject);
            }
            if (consume > satiated)
            {
                happiness += 1;
            }
            else if (consume < starving)
            {
                happiness -= 2;
            }
            consumeTimer = consumeTimerReset;
        }
        if(food < eatPoint)
        {
            eating = true;
            target = null;
            currentJob = state.search;
        }
    }

    public void OpenUI()
    {
        if (selected == true)
        {
            ui.OpenUIGatherInfo(type.jobSprite);
        }
    }
}
