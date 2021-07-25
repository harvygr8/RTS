using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEntityPrinter : MonoBehaviour
{


    // Update is called once per frame
    private void Start()
    {
        foreach (var thing in WorldEntity.Entities)
        {
            Debug.Log(thing);
        }
    }
}
