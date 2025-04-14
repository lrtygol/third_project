using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY : MonoBehaviour
{
    public Transform player;
    public int speed;
    void Start()
    {
        player = GameObject.Find("Main Camera/player").transform;
    }



    void Update()
    {
        if(transform.position.z<54)
        {
            Destroy(gameObject);
        }
        transform.LookAt(player);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    
}
