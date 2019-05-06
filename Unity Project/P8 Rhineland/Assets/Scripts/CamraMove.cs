using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraMove : MonoBehaviour
{
    [Header("CamMove")]
    public float camMoveSpeed;
    public float screenThickness;

    [Header("CamZoom")]
    public float camZoomSpeed;
    public float maxZoom;
    public float minZoom;

    void Update()
    {
        CameraMove();
        CameraZoom();
    }

    //cam movement
    void CameraMove()
    {
        Vector3 currPos = transform.position;

        //forward
        if (Input.GetAxis("Vertical") > 0 || Input.mousePosition.y >= Screen.height - screenThickness)
        {
            currPos.z -= camMoveSpeed * Time.deltaTime;
        }
        //back
        if (Input.GetAxis("Vertical") < 0 || Input.mousePosition.y <= screenThickness)
        {
            currPos.z += camMoveSpeed * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") > 0 || Input.mousePosition.x >= Screen.width - screenThickness)
        //right
        {
            currPos.x -= camMoveSpeed * Time.deltaTime;
        }
        //left
        if (Input.GetAxis("Horizontal") < 0 || Input.mousePosition.x <= screenThickness)
        {
            currPos.x += camMoveSpeed * Time.deltaTime;
        }

        if (Input.GetButtonUp("Horizontal") && Input.GetAxis("Horizontal") != 0 || Input.GetButtonUp("Vertical") && Input.GetAxis("Vertical") != 0)
        {
            Input.ResetInputAxes();
        }

        transform.position = currPos;
    }

    //scrool wheel zoom in and out
    void CameraZoom()
    {
        float f = Camera.main.fieldOfView;

        f += -Input.GetAxis("Mouse ScrollWheel") * camZoomSpeed;
        f = Mathf.Clamp(f, minZoom, maxZoom);

        Camera.main.fieldOfView = f;
    }
}
