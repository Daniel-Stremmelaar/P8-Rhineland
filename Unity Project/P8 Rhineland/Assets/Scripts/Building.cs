using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingType type;
    public ResourceManager r;
    public bool placing;
    public Material material;
    public Builder builder;
    private Collider c;
    private RaycastHit hit;
    public List<GameObject> colliding = new List<GameObject>();
    private bool placeable;
    // Start is called before the first frame update
    void Start()
    {
        r = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
        builder = GameObject.FindGameObjectWithTag("Builder").GetComponent<Builder>();
        c = GetComponent<Collider>();
    }

    // Update is called once per frame
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
            if (Input.GetButtonDown("Fire1") && placeable == true)
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
    }

    private void OnTriggerEnter(Collider other)
    {
        colliding.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        colliding.Remove(other.gameObject);
    }
}
