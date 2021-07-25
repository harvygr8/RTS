using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragGizmoCleanup : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
       if(com.CleanDGUnit)
       {
           DragAreaUnits.Clear();
           com.CleanDGUnit = false;
       }
       */
       Debug.Log("DG:Running");
       foreach(GameObject unit in UnitCommander.SelectedUnits)
       {
            Debug.Log("DG:"+unit);
       }
    }


    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log("DG:Collision!");
        if(col.gameObject.CompareTag("PlayerUnit"))
        {
            Debug.Log("DG:Collision!");
            if (!UnitCommander.SelectedUnits.Contains(col.gameObject))
            {
                UnitCommander.SelectedUnits.Add(col.gameObject);
            }
            //com.CleanDGUnit = false;
        }
    }
}
