using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject ShotGun;
    private Quaternion bulletRotation;

    void Update()
    {
        bulletRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, ShotGun.transform.position, bulletRotation);
        }
        
    }
}
