using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageEntity : MonoBehaviour
{
    public static readonly HashSet<StorageEntity> Entities = new HashSet<StorageEntity>();

    void Awake()
    {
        Entities.Add(this);
    }

    void OnDestroy()
    {
        Entities.Remove(this);
    }

}
