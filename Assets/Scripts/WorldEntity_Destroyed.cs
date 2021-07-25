using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEntity_Destroyed : MonoBehaviour
{

    public static readonly HashSet<WorldEntity_Destroyed> OfflineEntities = new HashSet<WorldEntity_Destroyed>();

    void Awake()
    {
        OfflineEntities.Add(this);
    }

    void OnDestroy()
    {
        OfflineEntities.Remove(this);
    }
}
