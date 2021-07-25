using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TurretLogic : MonoBehaviour
{
    public Material matRed;
    public Material matBlue;
    public GameObject[] LightOb;
    public bool isActive;
    public float timer = 3f;
    //public GameObject Player;
    float ogtimer;
    public AudioSource FXsound;
    public TurretRotShoot EnableShoot;

    // Start is called before the first frame update
    void Start()
    {
        ogtimer = timer;
        //Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Running");
        if (isActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SetRed();
                EnableShoot.canShoot = false;
                isActive = false;
                timer = ogtimer;
            }
        }
        if(Input.GetKey(KeyCode.Mouse0))
        {
            FXsound.Play();
            EnableShoot.canShoot = true;
            isActive = true;
            SetBlue();
        }
    }

    void SetBlue()
    {
        foreach (GameObject lightob in LightOb)
        {
            lightob.GetComponent<Renderer>().material = matBlue;
        }
    }
    void SetRed()
    {
        foreach (GameObject lightob in LightOb)
        {
            lightob.GetComponent<Renderer>().material = matRed;
        }
    }


}

