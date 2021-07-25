using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotShoot : MonoBehaviour
{
    public float timer;
    public GameObject bullet;
    public Transform firepoint;
    public Transform firepoint2;
    public Transform firepoint3;
    public Transform firepoint4;
    public bool canShoot=false;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime * 1f;
        if (canShoot)
        {
            if (timer > .4f)
            {
                GameObject newbullet = Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation) as GameObject;
                Rigidbody temp_newbullet;
                temp_newbullet = newbullet.GetComponent<Rigidbody>();
                temp_newbullet.GetComponent<Rigidbody>().AddForce(temp_newbullet.transform.forward * speed * Time.fixedDeltaTime, ForceMode.Impulse);

                GameObject newbullet2 = Instantiate(bullet, firepoint2.transform.position, firepoint2.transform.rotation) as GameObject;
                Rigidbody temp_newbullet2;
                temp_newbullet2 = newbullet2.GetComponent<Rigidbody>();
                temp_newbullet2.GetComponent<Rigidbody>().AddForce(temp_newbullet2.transform.forward * speed * Time.fixedDeltaTime, ForceMode.Impulse);

                GameObject newbullet3 = Instantiate(bullet, firepoint3.transform.position, firepoint3.transform.rotation) as GameObject;
                Rigidbody temp_newbullet3;
                temp_newbullet3 = newbullet3.GetComponent<Rigidbody>();
                temp_newbullet3.GetComponent<Rigidbody>().AddForce(temp_newbullet3.transform.forward * speed * Time.fixedDeltaTime, ForceMode.Impulse);

                GameObject newbullet4 = Instantiate(bullet, firepoint4.transform.position, firepoint4.transform.rotation) as GameObject;
                Rigidbody temp_newbullet4;
                temp_newbullet4 = newbullet4.GetComponent<Rigidbody>();
                temp_newbullet4.GetComponent<Rigidbody>().AddForce(temp_newbullet4.transform.forward * speed * Time.fixedDeltaTime, ForceMode.Impulse);

                timer = 0f;
            }
        }

    }
}
