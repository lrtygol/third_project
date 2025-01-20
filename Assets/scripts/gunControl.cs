using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunControl : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float sensitivity = 0.5f;
    void Update()
    {
        horizontal = Input.GetAxis("Mouse X") * sensitivity;
            transform.Rotate(0, horizontal, 0);
        vertical = Input.GetAxis("Mouse Y") * sensitivity;
            transform.Rotate(-vertical, 0, 0);

    }
}
