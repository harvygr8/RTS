using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SimpleJSON;
using System;

//if all else fails just go back to the original method and do taht with single files for each gameobject


[Serializable]
public class SaveManagerJSON : MonoBehaviour
{
    static readonly string savefile = "SaveGame.json";
    public GameObject[] prefabs;
    public string[] tags;
    JSONObject save;

    private void Awake()
    {
/*        save = new JSONObject();
        Load();*/
    }
    private void OnApplicationQuit()
    {
        //Save();
    }

    // Start is called before the first frame update
    void Start()
    {
        save = new JSONObject();
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("SAVING");
            Save();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Load();
        }
    }

    void Save()
    {
        int count = 0;
        string filename = Path.Combine(Application.persistentDataPath, savefile);

        if (File.Exists(filename))
        {
            File.Delete(filename);
        }

        foreach (GameObject unit in GameObject.FindGameObjectsWithTag("PlayerBuilding"))
        {

            JSONArray data = new JSONArray();
            data.Add(unit.transform.position.x);
            data.Add(unit.transform.position.y);
            data.Add(unit.transform.position.z);
            data.Add(unit.transform.rotation.x);
            data.Add(unit.transform.rotation.y);
            data.Add(unit.transform.rotation.z);
            data.Add(unit.transform.rotation.w);
            data.Add(unit.name);
            save.Add(unit.tag + count.ToString(), data);
            count++;
            //File.AppendAllText(filename, save.ToString());

        }


        foreach (GameObject unit in GameObject.FindGameObjectsWithTag("Resource"))
        {

            JSONArray data = new JSONArray();
            data.Add(unit.transform.position.x);
            data.Add(unit.transform.position.y);
            data.Add(unit.transform.position.z);
            data.Add(unit.transform.rotation.x);
            data.Add(unit.transform.rotation.y);
            data.Add(unit.transform.rotation.z);
            data.Add(unit.transform.rotation.w);
            data.Add(unit.name);
            save.Add(unit.tag + count.ToString(), data);
            count++;
            //File.AppendAllText(filename, save.ToString());

        }

        foreach (GameObject unit in GameObject.FindGameObjectsWithTag("PlayerUnit"))
        {
            JSONArray data = new JSONArray();
            data.Add(unit.transform.position.x);
            data.Add(unit.transform.position.y);
            data.Add(unit.transform.position.z);
            data.Add(unit.transform.rotation.x);
            data.Add(unit.transform.rotation.y);
            data.Add(unit.transform.rotation.z);
            data.Add(unit.transform.rotation.w);
            data.Add(unit.name);
            data.Add(unit.gameObject.GetComponent<Unit>().hasMined);
            data.Add(unit.gameObject.GetComponent<Unit>().targetName);
            save.Add(unit.tag+count.ToString(), data);
            count++;
            //File.AppendAllText(filename, save.ToString());

        }

        Debug.Log(save);
        File.WriteAllText(filename, save.ToString());
    }
    
    void Load()
    {
        string filename = Path.Combine(Application.persistentDataPath, savefile);
        if (!File.Exists(filename))
        {
            File.Create(filename).Dispose();
        }
        string jsonString = File.ReadAllText(filename);
        JSONObject data = (JSONObject)JSON.Parse(jsonString);
        //Debug.Log(data);

        foreach(KeyValuePair<string,JSONNode> node in data)
        {        
            GameObject unit = null;
            string unit_name = node.Value[7];

            if(unit_name.StartsWith("silo"))
            {
                unit = Instantiate(prefabs[0]);
            }
            else if (unit_name.StartsWith("Worker"))
            {
                unit = Instantiate(prefabs[1]);
                unit.GetComponent<Unit>().hasMined = node.Value[8];
                unit.GetComponent<Unit>().targetName = node.Value[9];
            }
            else if (unit_name.StartsWith("resource"))
            {
                unit = Instantiate(prefabs[2]);
            }
            //GameObject unit = Instantiate(prefabs[0]);
            unit.transform.position = new Vector3(node.Value[0],node.Value[1],node.Value[2]);
            unit.transform.rotation = new Quaternion(node.Value[3], node.Value[4], node.Value[5], node.Value[6]);
            unit.name = unit_name;

            //Debug.Log(node.Value[0]);
        }
    }
}
