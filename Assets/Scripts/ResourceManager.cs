using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    public static float RegentValue;
    public static int RegentTowerCount;
    public static int RegentPerSecond;
    public bool ShowValue=false;
    private void Awake()
    {
        RegentValue = 50f;
    }

    public static void AddResource(int amount)
    {
        RegentValue += amount;
    }

    void ShowResource()
    {
        Debug.Log("Regent:"+RegentValue.ToString());
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    public void Update()
    {
        RegentPerSecond = RegentTowerCount * 2;
        if (ShowValue)
        {
            ShowResource();
            ShowValue = false;
        }
    }
}
