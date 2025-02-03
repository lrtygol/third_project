using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunControl : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    [Range(0.1f, 9f)] [SerializeField] float sensitivity = 0.5f;
    [Range(0f, 90f)][SerializeField] float yLimited;
    [Range(0f, 90f)][SerializeField] float xLimited;
    Vector2 Rotation = Vector2.zero;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        horizontal = Input.GetAxis("Mouse X") * sensitivity;
            
        vertical = Input.GetAxis("Mouse Y") * sensitivity;
            Rotation.x += horizontal;
            Rotation.y += vertical;
            Rotation.y = Mathf.Clamp(Rotation.y, -yLimited, yLimited);
            Rotation.x = Mathf.Clamp(Rotation.x, -xLimited, xLimited);
        var xQuaternion = Quaternion.AngleAxis(Rotation.x, Vector3.up);
        var yQuaternion = Quaternion.AngleAxis(Rotation.y, Vector3.left);
        Debug.Log(yQuaternion);
        transform.localRotation = xQuaternion * yQuaternion;

    }
}
