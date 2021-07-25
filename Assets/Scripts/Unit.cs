using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Unit : MonoBehaviour
{
    public bool IsSelected = false;
    public GameObject SelectorGFX;
    private Transform foll;
    public bool hasMined = false;
    /*    public Transform firepoint;
        public GameObject bullet;
        public float fireRate = 0.5f;
        private float lastShot = 0.0f;
        public float speed;
        public bool CanShoot = true;*/

    [SerializeField] private NavMeshAgent agent;
    public Transform target = null;
    public string targetName=null;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        if (targetName != null)
        {
            target = GameObject.Find(targetName).transform;
            if(!target)
            {
                target = null;
            }
        }
        else
        {
            target = null;
        }
        //CanShoot = true;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (IsSelected)
        {
            SelectorGFX.SetActive(true);
        }
        else
        {
            SelectorGFX.SetActive(false);
        }

        if(target !=null)
        {
            if(target.gameObject.CompareTag("Resource"))
            {
                StartMiningRoutine();
            }

            if(target.gameObject.CompareTag("WorldTile"))
            {
                agent.SetDestination(target.transform.position);
            }
        }
        else
        {
            //Debug.Log("Idling");
        }
    }

    void StartMiningRoutine()
    {
        Debug.Log("Mining Routine Started!");
        if (!hasMined)
        {
            GoToNode();
        }
        if(hasMined)
        {
            GoToNearestSilo();
        }
    }


    void GoToNode()
    {
        //transform.LookAt(target);
        target = GameObject.Find(targetName).transform;
        agent.SetDestination(target.position);
        targetName = target.gameObject.name;
        if (Vector3.Distance(this.transform.position, target.transform.position) <= 1f)
        {
            agent.ResetPath();
            hasMined = true;
            // MoveTo(target);
        }
    }

    void GoToNearestSilo()
    {
        Vector3 pos = this.transform.position;
        float dist = float.PositiveInfinity;
        Transform silo = null;
        foreach (var obj in StorageEntity.Entities)
        {
            var d = (pos - obj.transform.position).sqrMagnitude;
            if (d < dist)
            {
                silo = obj.transform;
                dist = d;
            }
        }

        //ALSO ADD IN CHECK TO SEE IF SILO IS FULL

        //transform.LookAt(silo);
        agent.SetDestination(silo.position);

        if (Vector3.Distance(this.transform.position, silo.transform.position) <= 1f)
        {
            agent.ResetPath();
            hasMined = false;
        }
    }

}

/*    void Shoot()
    {
        *//*                if (CanShoot)  puut this in update
                {
                    if (Time.time > fireRate + lastShot)
                    {
                        //Debug.Log("SHOOT");
                        Shoot();
                    }
                }*//*

        GameObject newbullet = Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation) as GameObject;
        Rigidbody temp_newbullet;
        temp_newbullet = newbullet.GetComponent<Rigidbody>();
        temp_newbullet.GetComponent<Rigidbody>().AddForce(temp_newbullet.transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
        Destroy(GameObject.Find("MGBullet(Clone)"), 1f);
        lastShot = Time.time;
    }*/
