using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    [SerializeField]
    private enum State

    {
        IDLE,
        FIND,
        ATTACK
    }

    [SerializeField] private float EnemyDetectionRange = 5f;
    [SerializeField] private State CurrentState;

    [SerializeField] private NavMeshAgent agent;
    //[SerializeField] private GameObject player;

    private Transform foll;
    public Transform firepoint;
    public GameObject bullet;
    public float fireRate = 0.5f;
    private float lastShot = 0.0f;
    public float speed;
    public bool CanShoot = true;
    [SerializeField] private WorldEntity targ = null;
    // Start is called before the first frame update
    void Start()
    {
        CurrentState = State.IDLE;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentState)
        {
            case State.IDLE:
                //Master controller initiates IDLE and FIND condition
                Debug.Log("IDLING");
                if (WorldEntity.Entities.Count > 0)
                {
                    CurrentState = State.FIND;
                }
                break;

            case State.FIND:
                Debug.Log("FINDING");
                Vector3 pos = this.transform.position;
                float dist = float.PositiveInfinity;
                //targ = null;
                //var count = 0;
                if(WorldEntity.Entities.Count==0)
                {
                    CurrentState = State.IDLE;
                }
                foreach (var obj in WorldEntity.Entities)
                {
                    var d = (pos - obj.transform.position).sqrMagnitude;
                    //count++;
                    if (d < dist)
                    {
                        targ = obj;
                        dist = d;
                    }
                    //if(count<=0)
                    //{
                    //    CurrentState = State.IDLE;
                    //}
                }
                if (targ != null)
                {
                    foll = targ.transform;
                    transform.LookAt(foll);
                    agent.SetDestination(foll.position);
                    if (Vector3.Distance(this.transform.position, targ.transform.position) <= agent.stoppingDistance)
                    {
                        CurrentState = State.ATTACK;
                    }
                }

                break;

            case State.ATTACK:
                Debug.Log("ATTACKING");
                if (Time.time > fireRate + lastShot)
                {
                    //Debug.Log("SHOOT");
                    Shoot();
                }
                //Vector3.Distance(this.transform.position, targ.transform.position) > 4f
                if (targ==null)
                {
                    CurrentState = State.FIND;
                }


                break;

            default:
                break;

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