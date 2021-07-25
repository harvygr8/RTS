
using UnityEngine;

using System.Collections;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    NavMeshAgent agent;
    private GameObject target;
    private Transform foll;
    //public GameObject Fx;
    //public float spawnFxtime;
    //public bool st=true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //target = GameObject.FindWithTag("Player");          //thank you MarioRuiz!!
        //foll = target.transform;
    }
    void FixedUpdate()
    {
        target = GameObject.FindWithTag("Player");          //thank you MarioRuiz!!
        foll = target.transform;
        
        transform.LookAt(foll);
        agent.SetDestination(foll.position);

        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        

    }
}