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

    [Header("Data")]
    public int food;
    public int happiness;

    // Start is called before the first frame update
    void Start()
    {
        gathering = true;
        currentJob = state.search;
        agent = GetComponent<NavMeshAgent>();
        trigger = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
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
        type.FoodConsumption();
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
            type.Deliver(gathered, collision.gameObject);
            gathered = 0;
            gathering = true;
            target = null;
            currentJob = state.search;
        }
    }
}
