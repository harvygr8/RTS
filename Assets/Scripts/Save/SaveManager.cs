using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    [SerializeField] Unit unitprefab;
    [SerializeField] Building bprefab;
    public static List<Unit> UnitsToSave = new List<Unit>();
    public static List<Building> BuildingsToSave = new List<Building>();
    public string directory="/SaveData/UnitData";
 //TODO : just make new count dir for building or add something to save nd load files to make them unique``
    public string dcount= "/SaveData.count";

    private void Awake()
    {
        //LoadUnits();
        //LoadBuildings();
    }
    private void OnApplicationQuit()
    {
        //SaveUnits();
       //SaveBuildings();
    }

    public void SaveUnits()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + directory + SceneManager.GetActiveScene().buildIndex;
        string countPath = Application.persistentDataPath + dcount + SceneManager.GetActiveScene().buildIndex;

        FileStream countStream = new FileStream(countPath, FileMode.Create);
        bf.Serialize(countStream, UnitsToSave.Count);
        countStream.Close();

        for (int i =0;i<UnitsToSave.Count;i++)
        {
            //take this fstream outside in OPEN mode and check if it can serialize multiple objects in single file
            FileStream file = new FileStream(path + i,FileMode.Create);
            SaveObject so = new SaveObject(UnitsToSave[i]);
            bf.Serialize(file, so);
            file.Close();
        }
        //maybe try the serialization fstream and SO outside
    }

    public void SaveBuildings()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + directory +"BLD" +SceneManager.GetActiveScene().buildIndex;
        string countPath = Application.persistentDataPath + dcount +"BLD" +SceneManager.GetActiveScene().buildIndex;
        
        FileStream countStream = new FileStream(countPath, FileMode.Create);
        bf.Serialize(countStream, BuildingsToSave.Count);
        countStream.Close();

        for (int i = 0; i < BuildingsToSave.Count; i++)
        {
            FileStream file = new FileStream(path + i, FileMode.Create);
            SaveObject so = new SaveObject(BuildingsToSave[i]);
            bf.Serialize(file, so);
            file.Close();
        }
        //maybe try the serialization fstream and SO outside
    }

    public void LoadUnits()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + directory + SceneManager.GetActiveScene().buildIndex;
        string countPath = Application.persistentDataPath + dcount + SceneManager.GetActiveScene().buildIndex;
        int UnitCount = 0;
        if (File.Exists(countPath))
        {
            FileStream countStream = new FileStream(countPath, FileMode.Open);
            UnitCount=(int)bf.Deserialize(countStream);
            countStream.Close();
        }
        else
        {
            Debug.Log("ERROR");
        }

        for (int i = 0; i < UnitCount; i++)
        {
            //create new fs for every unit
            if (File.Exists(countPath))
            {
                FileStream file = new FileStream(path + i, FileMode.Open);
                SaveObject so = bf.Deserialize(file) as SaveObject;
                file.Close();

                Vector3 position = new Vector3(so.pos[0], so.pos[1], so.pos[2]);
                //add extra unit type info here and when loaded switch case to appropriate prefab
                Unit unit = Instantiate(unitprefab,position,Quaternion.identity);
            }
            else
            {
                Debug.Log("ERROR2");
            }
        }
    }

    public void LoadBuildings()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + directory + "BLD" + SceneManager.GetActiveScene().buildIndex;
        string countPath = Application.persistentDataPath + dcount + "BLD" + SceneManager.GetActiveScene().buildIndex;
       
        int BuildingCount = 0;
        if (File.Exists(countPath))
        {
            FileStream countStream = new FileStream(countPath, FileMode.Open);
            BuildingCount = (int)bf.Deserialize(countStream);
            countStream.Close();
        }
        else
        {
            Debug.Log("ERROR");
        }

        for (int i = 0; i < BuildingCount; i++)
        {
            //create new fs for every unit
            if (File.Exists(countPath))
            {
                FileStream file = new FileStream(path + i, FileMode.Open);
                SaveObject so = bf.Deserialize(file) as SaveObject;
                file.Close();

                Vector3 position = new Vector3(so.pos[0], so.pos[1], so.pos[2]);
                Building building = Instantiate(bprefab, position, Quaternion.identity);
            }
            else
            {
                Debug.Log("ERROR2");
            }
        }
    }
}
