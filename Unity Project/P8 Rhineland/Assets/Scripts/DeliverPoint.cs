using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverPoint : MonoBehaviour
{
    public ResourceManager r;
    // Start is called before the first frame update
    void Start()
    {
        r = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
    }
}
