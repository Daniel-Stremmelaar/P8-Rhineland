using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gatherer : MonoBehaviour
{
    [Header("Behavior")]
    public GathererType type;
    private enum state { search, gather, deliver, eat };
    private state currentJob;

    [Header("Navigation")]
    public int triggerGrow;
    private NavMeshAgent agent;
    private SphereCollider trigger;
    private GameObject target;
    private GameObject home;

    [Header("Gathering")]
    private bool gathering;
    private int gathered;
    private float timer;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == type.resource)
        {
            target = other.gameObject;
        }
        if(other.tag == "Home")
        {
            home = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(currentJob == state.gather && other.gameObject.tag == type.resource)
        {
            timer += Time.deltaTime;
            if(timer >= type.gatherTime)
            {
                gathered += 1;
                timer = 0.0f;
                if(gathered == type.carryCap)
                {
                    gathering = false;
                    home = null;
                    currentJob = state.search;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Home")
        {
            type.Deliver(gathered);
            gathered = 0;
            gathering = true;
            target = null;
            currentJob = state.search;
        }
    }
}
