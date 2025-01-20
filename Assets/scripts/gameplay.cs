using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameplay : MonoBehaviour
{
    public float speed = 10f;
    

    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnCollisionEnter");
        if (other.gameObject.CompareTag("mimic"))
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
            
    }
}
