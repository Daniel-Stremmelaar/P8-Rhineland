using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraMove : MonoBehaviour
{
    [Header("CamZoom")]
    public float camZoomSpeed;
    public float maxZoom;
    public float minZoom;

    public GameObject empty;
    RaycastHit raycast;

    [Header("Selecting")]
    public GameObject selected;

    UIManager uIManager;
    RaycastHit unitHit = new RaycastHit();

    private void Start()
    {
        uIManager = GameObject.FindWithTag("Builder").GetComponent<UIManager>();
        CreateEmpty();
    }

    void Update()
    {
        CameraZoom();
        ScelectUnit();
    }

    //scrool wheel zoom in and out
    void CameraZoom()
    {
        float f = Camera.main.fieldOfView;

        f += -Input.GetAxis("Mouse ScrollWheel") * camZoomSpeed;
        f = Mathf.Clamp(f, minZoom, maxZoom);

        Camera.main.fieldOfView = f;
    }

    void CreateEmpty()
    {
        Physics.Raycast(transform.position, transform.forward, out raycast, 500f);
        if (raycast.transform.tag == "Terrain")
        {
            GameObject g = Instantiate(empty,raycast.point,Quaternion.identity);
            transform.SetParent(g.transform);
        }
    }

    void ScelectUnit()
    {
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out unitHit);

        if (Input.GetButtonDown("Fire1"))
        {
            if (unitHit.transform.tag == "Gatherer")
            {
                Debug.Log("Hit " + unitHit.transform.name);
                unitHit.transform.gameObject.GetComponent<Gatherer>().selected = true;
                unitHit.transform.gameObject.GetComponent<Gatherer>().OpenUI();
            }
            else if(unitHit.transform.tag == "Home")
            {
                selected = unitHit.transform.gameObject;
                uIManager.SelectedPanel(unitHit.transform.gameObject);
            }
            else
            {
                Debug.Log("MIS CLICK");
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            uIManager.Deselect();
            Debug.Log("Deselect");
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Gatherer"))
            {
                g.GetComponent<Gatherer>().selected = false;
            }
            GameObject.FindWithTag("Builder").GetComponent<UIManager>().gatherInfoPanel.SetActive(false);
        }
    }

}
