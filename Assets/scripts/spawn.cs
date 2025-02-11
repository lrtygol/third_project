using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject[] mimic_spawn;
    private int index;

    void Start()
    {
        InvokeRepeating("Spawn", 3, 4);
    }


    void Spawn()
    {
        index = Random.Range(0, mimic_spawn.Length);
        Vector3 pos = new Vector3(Random.Range(-50, 15), 6, Random.Range(100, 170));
        Quaternion Rotation = Quaternion.Euler(0,0,0);
        Instantiate(mimic_spawn[index], pos, Rotation);
    }
}
