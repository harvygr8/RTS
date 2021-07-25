using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject prefab;
    public GameObject on_prefab;
    public GameObject[] blueprint_prefabs;
    public GameObject[] final_prefabs;
    public Vector3 place;
    RaycastHit hit;
    public bool isPlacing = true;
    public GameObject pref;
    public GameObject bld;
    public GameObject unitcommander;
    Vector3 final;
    // Start is called before the first frame update
    void Start()
    {
        //unitcommander = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //currentBuilding.position = new Vector3(place.x, 0, place.z);
        if (Input.GetKeyDown(KeyCode.B))
        {
            unitcommander.SetActive(false);
            isPlacing = true;
            pref = Instantiate(prefab, hit.point, Quaternion.identity);
        }
        if (isPlacing)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("PlaceablePos"))
                {
                    pref.transform.position = hit.point;
                    final = pref.transform.position;
                    //Instantiate(prefab, hit.point, Quaternion.identity);
                }
                if (Input.GetMouseButtonDown(0))
                {
                    Destroy(pref);
                    pref = null;
                    bld = Instantiate(on_prefab, final, Quaternion.identity);
                    bld.name = on_prefab.name + Random.Range(100, 900).ToString();
                    isPlacing = false;
                    unitcommander.SetActive(true);
                }
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Destroy(pref);
                unitcommander.SetActive(true);
                isPlacing = false;
            }
        }
    }

    public void SetDrone()
    {
        prefab = blueprint_prefabs[0];
        on_prefab = final_prefabs[0];
    }
    public void SetResource()
    {
        prefab = blueprint_prefabs[1];
        on_prefab = final_prefabs[1];
    }


}
