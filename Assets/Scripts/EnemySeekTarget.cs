using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemySeekTarget : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField]
    private Transform foll;
    public Transform firepoint;
    public GameObject bullet;
    public float fireRate = 0.5f;
    private float lastShot = 0.0f;
    public float speed;
    public bool CanShoot = true;
    //public float TimeLeft = 1f;
    //public GameObject Fx;
    //public float spawnFxtime;
    //public bool st=true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //target = GameObject.FindWithTag("Player");          //thank you MarioRuiz!!
        //foll = target.transform;
    }
    void Update()
    {
        Vector3 pos = this.transform.position;
        float dist = float.PositiveInfinity;
        WorldEntity targ = null;
        foreach (var obj in WorldEntity.Entities)
        {
            var d = (pos - obj.transform.position).sqrMagnitude;
            if (d < dist)
            {
                targ = obj;
                dist = d;
            }
        }
        foll = targ.transform;
        transform.LookAt(foll);
        agent.SetDestination(foll.position);
        //Debug.Log("Stopping Distance" + agent.stoppingDistance);
        //Debug.Log(agent.isStopped);

        if (Vector3.Distance(this.transform.position, targ.transform.position) <= agent.stoppingDistance)
        {
            CanShoot = true;
            //TimeLeft -= Time.deltaTime;
            //if (TimeLeft <= 0f)
            //{
            //    CanShoot = true;
            //    TimeLeft = 1f;
            //}
        }
        
        if (Vector3.Distance(this.transform.position, targ.transform.position) > 4f)
        {
            CanShoot = false;
        }

        if (CanShoot)
        {
            if (Time.time > fireRate + lastShot)
            {
                //Debug.Log("SHOOT");
                Shoot();
            }
        }

    }
    void Shoot()
    {

        GameObject newbullet = Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation) as GameObject;
        Rigidbody temp_newbullet;
        temp_newbullet = newbullet.GetComponent<Rigidbody>();
        temp_newbullet.GetComponent<Rigidbody>().AddForce(temp_newbullet.transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
        Destroy(GameObject.Find("MGBullet(Clone)"), 1f);
        lastShot = Time.time;
    }


}
