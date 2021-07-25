using UnityEngine;

[System.Serializable]
public class SaveObject
{
    public float[] pos = new float[3];

    public SaveObject(Building building)
    {
        Vector3 unitPos = building.transform.position;
            //unit.transform.position;
        pos = new float[]
        {
            unitPos.x,unitPos.y,unitPos.z
        };
    }

    public SaveObject(Unit unit)
    {
        //add type of unit
        Vector3 unitPos = unit.transform.position;
        //unit.transform.position;
        pos = new float[]
        {
            unitPos.x,unitPos.y,unitPos.z
        };
    }
}
