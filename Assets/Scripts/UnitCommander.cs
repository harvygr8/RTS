using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class UnitCommander : MonoBehaviour
{
    public static List<GameObject> SelectedUnits = new List<GameObject>();

    public Camera camera;
    public GameObject gz;
    public GameObject DragGizmo;
    public GameObject PathGizmo;
    public GameObject DummyUIBar;
    public GameObject[] SelectionUIComponents;
    public bool ShowUnits = false;
    public bool done=false;
    public bool CleanDGUnit = false;
    Vector3 temp;
    bool m_Started;
    // Start is called before the first frame update
    void Start()
    {
        m_Started = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*HANDLES GIZMO CODE*/

        // bool once;
/*        if (gz)
        {
            Debug.Log("BRANCH");
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            //temp = gz.transform.localScale;
            //dont forget to CLAMP TO PREVENT NEGATIVE VALUES
            gz.transform.localScale += new Vector3(x, 0, -y);
        }*/
/*        if (Input.GetMouseButton(0))
        {
            //SelectedUnits.Clear();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                //WorldTile is tag given to collider present inside the tiles hierarchy
                if (hitInfo.collider.gameObject.CompareTag("WorldTile"))
                {
                    Debug.Log("GGG:Hit WorldTile");
                    if (!done)
                    {
                        gz = Instantiate(DragGizmo);
                        gz.transform.position = hitInfo.point - new Vector3(.2f, 0, -.2f);
                        //gz. = Input.mousePosition;
                        //gz.transform.localScale = new Vector3(0, 0, 0);
                        done = true;
                        //Debug.Log(done);
                    }
                }
            }
        }*/

        if (Input.GetMouseButtonUp(0))
        {
            done = false;
            //CleanDGUnit = true;
            foreach (GameObject unit in SelectedUnits)
            {
                unit.GetComponent<Unit>().IsSelected = true;
            }
            Destroy(gz);
        }



        /*HANDLES SINGLE CLICK UNIT SELECTION*/
        if (Input.GetMouseButtonDown(0))
        {
            if(EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            
/*            foreach (GameObject unit in SelectedUnits)
            {
                unit.GetComponent<Unit>().IsSelected = false;
            }
            WorkerDroneUI.SetActive(false);
            RegentTowerUI.SetActive(false);
            SelectedUnits.Clear();*/
            
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.CompareTag("Worker"))
                {
                    //ClearPreviousSelections();

                    if (!SelectedUnits.Contains(hitInfo.collider.gameObject))   
                    {
                        hitInfo.collider.gameObject.GetComponent<Unit>().IsSelected = true;
                        SelectedUnits.Add(hitInfo.collider.gameObject);
                        ClearUISelections();
                        DummyUIBar.SetActive(false);
                        SelectionUIComponents[0].SetActive(true);
                    }
                }
                if(hitInfo.collider.gameObject.CompareTag("WorldTile"))
                {
                    Debug.Log("CLICKED OFF!");

                    ClearPreviousSelections();
                    ClearUISelections();

                }
                if (hitInfo.collider.gameObject.CompareTag("Resource"))
                {
                    //doesnt have anything to do with selected units so that branch is not needed
                    ClearPreviousSelections();
                    ClearUISelections();
                    DummyUIBar.SetActive(false);
                    SelectionUIComponents[1].SetActive(true);
                }
            }
        }
        
        /*BELOW LOGIC HANDLES WHAT HAPPENS WHEN YOU RIGHT CLICK SOMEWHERE WITH UNITS SELECTED*/
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.CompareTag("EnemyDrone"))
                {
                    Debug.Log("EnemyDroneFound!");
                    foreach (GameObject unit in SelectedUnits)
                    {
                        unit.GetComponent<Unit>().target = hitInfo.collider.gameObject.transform;       //need to replace this with functions from unit class
                    }
                    //hitInfo.collider.gameObject.GetComponent<NavMeshAgent>().SetDestination(hitInfo.collider.gameObject.transform.position);
                }
                if (hitInfo.collider.gameObject.CompareTag("Resource"))
                {
                    Debug.Log("Starting Mining!");
                    foreach (GameObject unit in SelectedUnits)
                    {
                        unit.GetComponent<Unit>().targetName = hitInfo.collider.gameObject.name;
                        unit.GetComponent<Unit>().target = hitInfo.collider.gameObject.transform;
                        //unit.GetComponent<Unit>().StartMiningAtNode(hitInfo.collider.gameObject.transform);
                    }
                }
                if (hitInfo.collider.gameObject.CompareTag("WorldTile"))
                {
                    Debug.Log("Clicked On Terrain!");
                    foreach (GameObject unit in SelectedUnits)
                    {
                        unit.GetComponent<Unit>().hasMined = false;
                        unit.GetComponent<Unit>().targetName = null;
                        unit.GetComponent<Unit>().target = hitInfo.collider.gameObject.transform;
                        //unit.GetComponent<NavMeshAgent>().SetDestination(hitInfo.point);
                        GameObject gz=Instantiate(PathGizmo);
                        gz.transform.position = hitInfo.point;
                    }
                }
                
                /*
                else
                {
                    foreach (GameObject unit in SelectedUnits)
                    {
                        Debug.Log("Wrong Click!");
                        //unit.GetComponent<Unit>().targ = null;
                        unit.GetComponent<NavMeshAgent>().ResetPath();
                    }
                }
                */
            }
        }

        if (ShowUnits)
        {
            PrintList();
            ShowUnits = false;
        }
    }




    void ClearPreviousSelections()
    {
        //clear previous selections
        foreach (GameObject unit in SelectedUnits)
        {
            unit.GetComponent<Unit>().IsSelected = false;
        }

        SelectedUnits.Clear();
    }

    void ClearUISelections()
    {
        foreach (GameObject ui in SelectionUIComponents)
        {
            ui.SetActive(false);
        }
        DummyUIBar.SetActive(true);
    }

    void MoveObject()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            //drone.transform.position = hitInfo.point;
            //drone.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }
    void PrintList()
    {
        foreach(GameObject unit in SelectedUnits)
        {
            Debug.Log(unit.name);
        }
    }



}
