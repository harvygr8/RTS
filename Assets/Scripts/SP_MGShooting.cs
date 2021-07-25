using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class SP_MGShooting : MonoBehaviour
{
    //public float damage = 10f;
    //public float range = 100f;

    public float speed = 10f;
    public GameObject firepoint;
    public GameObject firepoint1;
    public GameObject firepoint2;
    public GameObject firepoint3;
    public int alt = 0;
    public GameObject bullet;
    public bool inRange;
    //public GameObject rld;
    public GameObject target;
    public float Rotspeed;
    //public bool shootAble = true;
    //public TextMeshProUGUI ammo;
    public AudioSource shoot;
    public Quaternion StartRot;
    Quaternion rotTarget;
    public float fireRate = 0.5f;
    private float lastShot = 0.0f;


    public void Start()
    {
        StartRot = this.transform.rotation;
    }


    public void Update()
    {

        if (inRange)
        {
            if (!target)
            {
                target = null;
                rotTarget = StartRot;
                inRange = false;
            }
            else
            {
                rotTarget = Quaternion.LookRotation(target.transform.position - this.transform.position);
            }
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, Time.deltaTime * Rotspeed);

            if (Quaternion.Angle(this.transform.rotation, rotTarget) <= 0.01f)
            {
                Debug.Log("MATCH");
                if (Time.time > fireRate + lastShot)
                {
                    Debug.Log("SHOOT");
                    Shoot();
                }
            }


        }
        else
        {
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, StartRot, Time.deltaTime * Rotspeed);
        }
    }
    
    public void Shoot()
    {
        shoot.Play();
        //ShootSound.Play();
        if (alt == 0)
        {
            bullet_create();
        }
        else if (alt == 1)
        {
            bullet_create1();
        }
        else if (alt == 2)
        {
            bullet_create2();
        }
        else if (alt == 3)
        {
            bullet_create3();
        }
    }



    void bullet_create()
    {

        GameObject newbullet = Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation) as GameObject;
        Rigidbody temp_newbullet;
        temp_newbullet = newbullet.GetComponent<Rigidbody>();
        temp_newbullet.GetComponent<Rigidbody>().AddForce(temp_newbullet.transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
        Destroy(GameObject.Find("MGBullet(Clone)"), 1f);
        alt = 1;
        lastShot = Time.time;
    }
    void bullet_create1()
    {

        GameObject newbullet1 = Instantiate(bullet, firepoint1.transform.position, firepoint1.transform.rotation) as GameObject;
        Rigidbody temp_newbullet1;
        temp_newbullet1 = newbullet1.GetComponent<Rigidbody>();
        temp_newbullet1.GetComponent<Rigidbody>().AddForce(temp_newbullet1.transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
        Destroy(GameObject.Find("MGBullet(Clone)"), 1f);
        alt = 2;
        lastShot = Time.time;

    }

    void bullet_create2()
    {

        GameObject newbullet2 = Instantiate(bullet, firepoint2.transform.position, firepoint2.transform.rotation) as GameObject;
        Rigidbody temp_newbullet2;
        temp_newbullet2 = newbullet2.GetComponent<Rigidbody>();
        temp_newbullet2.GetComponent<Rigidbody>().AddForce(temp_newbullet2.transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
        Destroy(GameObject.Find("MGBullet(Clone)"), 1f);
        alt = 3;
        lastShot = Time.time;

    }

    void bullet_create3()
    {

        GameObject newbullet3 = Instantiate(bullet, firepoint3.transform.position, firepoint3.transform.rotation) as GameObject;
        Rigidbody temp_newbullet3;
        temp_newbullet3 = newbullet3.GetComponent<Rigidbody>();
        temp_newbullet3.GetComponent<Rigidbody>().AddForce(temp_newbullet3.transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
        Destroy(GameObject.Find("MGBullet(Clone)"), 1f);
        alt = 0;
        lastShot = Time.time;

    }



    private void OnTriggerStay(Collider collision)
    {
        if(collision.CompareTag("EnemyDrone"))
        {
            inRange = true;
            target = collision.gameObject;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("EnemyDrone"))
        {
            inRange = false;
            target = null;
        }
    }
}
