using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LineTool : MonoBehaviour
{
    public GameObject Line;
    public GameObject NewLine;
    public Transform pos1;
    public Transform pos2;
    RaycastHit hit;
    public bool isPlacing = false;
    public bool isLineStarted;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlacing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (!isLineStarted)
                    {
                        if (hit.collider.CompareTag("Resource"))
                        {
                            NewLine = Instantiate(Line);
                            pos1 = hit.collider.gameObject.transform;
                            NewLine.GetComponent<LineConfig>().start = pos1;
                            isLineStarted = true;
                        }
                    }
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (isLineStarted)
                    {
                        if (hit.collider.CompareTag("Resource"))
                        {
                            pos2 = hit.collider.gameObject.transform;
                            NewLine.GetComponent<LineConfig>().end = pos2;
                            //Destroy(NewLine);
                            NewLine = null;
                            isLineStarted = false;
                            isPlacing = false;

                        }
                    }
                }
            }
        }
    }

    public void EnableTool()
    {
        isPlacing = true;
    }
}
