using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGizmoCleanup : MonoBehaviour
{
    public float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (timer > 0f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale/1.5f, Time.deltaTime*2);
            timer -= Time.deltaTime;
        }
        if(timer<=0f)
        {
            Destroy(gameObject);
        }
    }
}
