using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoSelection : MonoBehaviour
{

    public GameObject PathGizmo;
    public GameObject gz;
    public bool done = false;

    void Start()
    {
    }

    void Update()
    {
        Ray ray;
        if (gz)
        {
            Debug.Log("BRANCH");
            float x = Input.GetAxis("Mouse X");
            gz.transform.localScale += gz.transform.localScale * x;
        }
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (!done)
                {
                    gz = Instantiate(PathGizmo);
                    gz.transform.position = hitInfo.point;
                    done = true;
                }
            }


        }

        if(Input.GetMouseButtonUp(0))
        {
            done = false;
            Destroy(gz);
        }
    }
}
