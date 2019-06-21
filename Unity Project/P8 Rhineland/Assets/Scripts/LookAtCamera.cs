using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    Transform camera;

    private void Update()
    {
        camera = Camera.main.transform;
        transform.LookAt(camera);
    }


}
