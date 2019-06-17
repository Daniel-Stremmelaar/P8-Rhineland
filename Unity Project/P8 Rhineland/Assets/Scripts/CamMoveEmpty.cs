using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoveEmpty : MonoBehaviour
{
    [Header("CamMove")]
    public float camMoveSpeed;
    public float screenThickness;
    Vector3 move;
    CamraMove camraMove;

    [Header("CamRotate")]
    public float rotateSpeed;
    public Vector3 vector;
    public bool mayRot = true;

    private void Start()
    {
        camraMove = gameObject.GetComponentInChildren<CamraMove>();
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0f, 200f), camraMove.f, Mathf.Clamp(transform.position.z, 0f, 200f));

    }
    private void FixedUpdate()
    {
        if (mayRot == true)
        {
            CameraRotation();
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            MoveCamera();
        }
    }

    //cam movement
    void MoveCamera()
    {
        move.x = -Input.GetAxis("Horizontal");
        move.z = -Input.GetAxis("Vertical");
        transform.Translate(move * camMoveSpeed * Time.deltaTime);
    }

    //camera Rotate
    void CameraRotation()
    {
        GameObject empty = GetComponentInChildren<CamraMove>().empty;
        if (Input.GetButton("TurnLeft"))
        {
            //rotate left
            transform.Rotate(vector * Time.deltaTime * rotateSpeed);
        }
        if (Input.GetButton("TurnRight"))
        {
            //rotate right
            transform.Rotate(-vector * Time.deltaTime * rotateSpeed);
        }
    }
}
