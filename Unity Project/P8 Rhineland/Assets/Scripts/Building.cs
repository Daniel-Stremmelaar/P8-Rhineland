using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingType type;
    public ResourceManager r;
    public bool placing;
    private Collider c;
    // Start is called before the first frame update
    void Start()
    {
        r = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
        c = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(placing == true)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                transform.position = hit.point;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                placing = false;
                c.enabled = true;
            }
            if (Input.GetButtonDown("Fire2"))
            {
                Destroy(gameObject);
            }

            c.enabled = false;
        }
    }
}
