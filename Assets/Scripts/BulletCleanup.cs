using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCleanup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 1.4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject, 0.3f);
    }
}
