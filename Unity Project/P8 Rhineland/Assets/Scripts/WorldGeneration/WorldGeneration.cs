using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    [Header("Nodes")]
    public GameObject berryNode;
    public List<GameObject> woodList = new List<GameObject>();
    public List<GameObject> stoneList = new List<GameObject>();

    [Header("Amount")]
    public int woodNodeAmount;
    public int stoneAmount;
    public int berryAmount;

    public LayerMask mask;
    RaycastHit hit;
    Vector3 newWorldPos;

    float xSize;
    float zSize;
    float xPos;
    float zPos;
    float yPos;

    void Start()
    {
        xSize = GetComponent<Terrain>().terrainData.size.x;
        zSize = GetComponent<Terrain>().terrainData.size.z;
        Generate();
    }

    void Generate()
    {
        //spawn threes
        for (int i = 0; i < woodNodeAmount; i++)
        {
            xPos = Random.Range(0, xSize);
            zPos = Random.Range(0, zSize);
            if (Physics.Raycast(new Vector3(xPos, 500f, zPos), Vector3.down, out hit, Mathf.Infinity, mask))
            {
                if (hit.transform.tag == "Terrain")
                {
                    yPos = hit.point.y;
                    newWorldPos = new Vector3(xPos, yPos, zPos);

                    int r = Random.Range(0, woodList.Count);
                    Instantiate(woodList[r], newWorldPos, Quaternion.identity);
                }
            }
        }
        //spawn stone
        for (int i = 0; i < stoneAmount; i++)
        {
            xPos = Random.Range(0, xSize);
            zPos = Random.Range(0, zSize);
            if (Physics.Raycast(new Vector3(xPos, 500f, zPos), Vector3.down, out hit, Mathf.Infinity, mask))
            {
                if (hit.transform.tag == "Terrain")
                {
                    yPos = hit.point.y;
                    newWorldPos = new Vector3(xPos, yPos, zPos);

                    int r = Random.Range(0, stoneList.Count);
                    Instantiate(stoneList[r], newWorldPos, Quaternion.LookRotation(hit.normal)*Quaternion.Euler(90,0,0));
                }
            }
        }
        //spawn Berry
        for (int i = 0; i < berryAmount; i++)
        {
            xPos = Random.Range(0, xSize);
            zPos = Random.Range(0, zSize);
            if (Physics.Raycast(new Vector3(xPos,500f,zPos),Vector3.down,out hit,Mathf.Infinity,mask))
            {
                if (hit.transform.tag == "Terrain")
                {
                    yPos = hit.point.y;
                    newWorldPos = new Vector3(xPos, yPos, zPos);
                   
                    Instantiate(berryNode, newWorldPos, Quaternion.identity);
                }
            }
        }

    }
}
