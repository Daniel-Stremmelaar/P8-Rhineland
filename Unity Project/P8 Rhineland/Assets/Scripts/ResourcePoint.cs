using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePoint : MonoBehaviour
{
    public int amount;
    public List<Gatherer> current = new List<Gatherer>();

    public void Empty()
    {
        foreach(Gatherer g in current)
        {
            g.timer = 0.0f;
            g.target = null;
            g.currentJob = Gatherer.state.search;
        }
        Destroy(gameObject);
    }
}
