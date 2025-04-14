using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class fire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject ShotGun;
    private Quaternion bulletRotation;
    private float time = 0.8f;
    private int max_ammo = 2;
    private int now_ammo;
    private float time_reload = 2f;
    private bool is_reload = false;
    public GameObject Anim;
    private Animator animator;
    public AudioSource shoot;
    public AudioSource reload;
    public TextMeshProUGUI ammo_count;
    public Image[] UI_Images;
    public Sprite Full;
    public Sprite Half;
    public Sprite Empty;
    private Animator[] Transition;
    void Start()
    {
        Transition = new Animator[UI_Images.Length];
        for (int i = 0; i < UI_Images.Length; i++)
        {

            Transition[i] = UI_Images[i].GetComponent<Animator>();

        }
            
        animator = Anim.GetComponent<Animator>();
        now_ammo = max_ammo;

    }
    void Update()
    {
        bulletRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        if (Input.GetMouseButtonDown(0) & time <= 0 & now_ammo>0)
        {

            shoot.Play();
            now_ammo -= 1;
            Trigger();
            ammo_count.text = "патроны " + now_ammo.ToString() + "/2";
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
                animator.enabled = false;
                is_reload = false;
                now_ammo = max_ammo;
                Already();
                time_reload = 2f;
                ammo_count.text = "патроны " + now_ammo.ToString() + "/2";
            }
        }
        
        if (Input.GetKeyDown(KeyCode.R) & now_ammo == 0  & is_reload == false)
        {
            reload.Play();
            animator.enabled = true;
            is_reload = true;
            
        }
        
        //Debug.Log(now_ammo);
    }
    void Trigger()
    {
        
        for (int i =0; i< UI_Images.Length; i++ )
        {
            if (i == now_ammo)
            {
                Transition[i].SetTrigger("to_half");
                Transition[i].SetTrigger("to_empty");
            }

            
        }
        
    }
    void Already()
    {
        for (int i = 0; i < UI_Images.Length; i++)
        {
            Transition[i].SetTrigger("to_half");
            Transition[i].SetTrigger("to_bullet");
            


        }
    }


}
