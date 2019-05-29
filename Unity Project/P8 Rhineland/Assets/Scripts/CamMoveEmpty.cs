using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoveEmpty : MonoBehaviour
{
    [Header("CamMove")]
    public float camMoveSpeed;
    public float screenThickness;

    [Header("CamRotate")]
    public float rotateSpeed;
    public Vector3 vector;

    void Update()
    {
        CameraMove();
        CameraRotation();
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
    //camera Rotate
    void CameraRotation()
    {
        GameObject empty = GetComponentInChildren<CamraMove>().empty;
        if (Input.GetButton("TurnLeft"))
        {
            //rotate left
            //transform.RotateAround(empty.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
            transform.Rotate(vector * Time.deltaTime * rotateSpeed);
        }
        if (Input.GetButton("TurnRight"))
        {
            //rotate right
            transform.Rotate(-vector * Time.deltaTime * rotateSpeed);
        }
    }
}
