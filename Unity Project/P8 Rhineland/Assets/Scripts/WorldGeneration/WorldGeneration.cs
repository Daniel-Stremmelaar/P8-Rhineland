using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    [Header("Nodes")]
    public GameObject woodNode;
    public GameObject stoneNode;
    //public GameObject mineNode;

    [Header("Amount")]
    public int woodNodeAmount;
    public int stoneAmount;
    //public int mineAmount;

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
            if (Physics.Raycast(new Vector3(xPos,500f,zPos),Vector3.down,out hit,Mathf.Infinity,mask))
            {
                if (hit.transform.tag == "Terrain")
                {
                    yPos = hit.point.y;
                    newWorldPos = new Vector3(xPos, yPos, zPos);
                   
                    Instantiate(woodNode, newWorldPos, Quaternion.identity);
                }
                else
                {
                    Debug.Log("HIT THE ELSE");
                }
            }
        }
        //spawn stone
        for (int i = 0; i < stoneAmount; i++)
        {
            xPos = Random.Range(0, xSize);
            zPos = Random.Range(0, zSize);
            if (Physics.Raycast(new Vector3(xPos,500f,zPos),Vector3.down,out hit,Mathf.Infinity,mask))
            {
                if (hit.transform.tag == "Terrain")
                {
                    yPos = hit.point.y;
                    newWorldPos = new Vector3(xPos, yPos, zPos);
                   
                    Instantiate(stoneNode, newWorldPos, Quaternion.identity);
                }
            }
        }
        //spawn mine
        /*for (int i = 0; i < mineAmount; i++)
        {
            xPos = Random.Range(0, xSize);
            zPos = Random.Range(0, zSize);
            if (Physics.Raycast(new Vector3(xPos,500f,zPos),Vector3.down,out hit,Mathf.Infinity,mask))
            {
                if (hit.transform.tag == "Terrain")
                {
                    yPos = hit.point.y;
                    newWorldPos = new Vector3(xPos, yPos, zPos);
                   
                    Instantiate(mineNode, newWorldPos, Quaternion.identity);
                }
            }
        }*/
        
    }
}
