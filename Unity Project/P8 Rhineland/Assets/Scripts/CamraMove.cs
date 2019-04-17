using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraMove : MonoBehaviour
{
    public float camMoveSpeed;
    public float screenThickness;

    void Update()
    {
        CameraMove();
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

        transform.position = currPos;
    }

    //scrool wheel zoom in and out
}
