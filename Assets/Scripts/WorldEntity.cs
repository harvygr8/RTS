using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEntity : MonoBehaviour
{

    public static readonly HashSet<WorldEntity> Entities = new HashSet<WorldEntity>();

    void Awake()
    {
        Entities.Add(this);
    }

    void OnDestroy()
    {
        Entities.Remove(this);
    }


}
