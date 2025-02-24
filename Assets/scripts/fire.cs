using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject ShotGun;
    private Quaternion bulletRotation;
    private float time = 0.8f;
    private int max_ammo = 5;
    private int now_ammo;
    private float time_reload = 2f;
    private bool is_reload = false;
    void Start()
    {
        now_ammo = max_ammo;
    }
    void Update()
    {
        bulletRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        if (Input.GetMouseButtonDown(0) & time <= 0 & now_ammo>0)
        {
            now_ammo -= 1;

         Instantiate(bullet, ShotGun.transform.position, bulletRotation);
         time = 0.8f; 
        }
        
        if (time > 0)
        {
            time -= Time.deltaTime; // Вычитаем из времени длительность кадра (не совсем так, но это для упрощения)
        }
        if (is_reload)
        {
            time_reload -=Time.deltaTime;
            if (time_reload <= 0)
            {
                is_reload = false;
                now_ammo = max_ammo;
                time_reload = 2f;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.R) & now_ammo == 0  & is_reload == false)
        {
            
            is_reload = true;
            
        }
        
        Debug.Log(now_ammo);
    }
}
