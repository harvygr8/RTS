using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    public Transform target;
    public bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotTarget = Quaternion.LookRotation(target.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, Time.deltaTime * 20f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("EnemyDrone"))
        {
            inRange = true;
            target = collision.gameObject.transform;
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

