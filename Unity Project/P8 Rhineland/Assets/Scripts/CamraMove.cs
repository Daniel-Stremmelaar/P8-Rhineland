using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    [Header("Sound")]
    public AudioClip click01;
    public List<AudioClip> unitSound = new List<AudioClip>();

    UIManager uIManager;
    SoundManager soundManager;
    RaycastHit unitHit = new RaycastHit();

    private void Awake()
    {
        CreateEmpty();
    }

    private void Start()
    {
        uIManager = GameObject.FindWithTag("Builder").GetComponent<UIManager>();
        soundManager = GameObject.FindWithTag("Builder").GetComponent<SoundManager>();
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
                int i = Random.Range(0, unitSound.Count);

                soundManager.Play2DSound(unitSound[i]);

                Debug.Log("Hit " + unitHit.transform.name);
                unitHit.transform.gameObject.GetComponent<Gatherer>().selected = true;
                unitHit.transform.gameObject.GetComponent<Gatherer>().OpenUI();
            }
            else if(unitHit.transform.tag == "Home" || unitHit.transform.tag == "TownHall")
            {
                soundManager.Play2DSound(click01);

                selected = unitHit.transform.gameObject;
                uIManager.SelectedPanel(unitHit.transform.gameObject);
            }
            else
            {
                Debug.Log(unitHit.transform.tag + "  misKlick");
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
