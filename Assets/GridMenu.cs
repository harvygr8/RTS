using UnityEngine;

public class GridMenu : MonoBehaviour
{
    public Transform hexPrefab;
    public Transform hexPrefab2;
    public Transform parentPos;
    public Transform gizmo;
    public int gridWidth = 11;
    public int gridHeight = 11;
    public int counter = 0;

    float hexWidth = 1.732f;
    float hexHeight = 2.0f;
    public float gap = 0.0f;

    Vector3 startPos;

    void Start()
    {
        Random.seed = 222;
        Debug.Log("GS:START!");
        AddGap();
        CalcStartPos();
        CreateGrid();
        this.transform.localScale = new Vector3(100, 100, 100);
    }

    void AddGap()
    {
        hexWidth += hexWidth * gap;
        hexHeight += hexHeight * gap;
    }

    void CalcStartPos()
    {
        float offset = 0;
        if (gridHeight / 2 % 2 != 0)
            offset = hexWidth / 2;

        float x = -hexWidth * (gridWidth / 2) - offset;
        float z = hexHeight * 0.75f * (gridHeight / 2);

        startPos = new Vector3(parentPos.transform.position.x, 0, parentPos.transform.position.z);
    }

    Vector3 CalcWorldPos(Vector2 gridPos)
    {
        float offset = 0;
        if (gridPos.y % 2 != 0)
            offset = hexWidth / 2;

        float x = startPos.x + gridPos.x * hexWidth + offset;
        float z = startPos.z - gridPos.y * hexHeight * 0.75f;

        return new Vector3(x, 0, z);
    }

    float RandomNum()
    {
        return Random.value;
    }
    void CreateGrid()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                counter++;
                Debug.Log(x + " " + y);
                if (counter <= 25 || counter > 50 && counter <= 75 || counter > 100 && counter <= 125 || counter > 150 && counter < 175 || counter > 200 && counter < 225)
                {
                    Transform hex = Instantiate(hexPrefab2) as Transform;
                    Vector2 gridPos = new Vector2(x, y);
                    hex.position = CalcWorldPos(gridPos);
                    hex.parent = this.transform;
                    hex.name = "GreenHexagon" + x + "|" + y;
                    Vector3 hexCentre = new Vector3(hex.position.x, 0, hex.position.z);
                    Transform giz = Instantiate(gizmo, hexCentre, Quaternion.identity);
                    giz.parent = this.transform;
                }
                else
                {
                    float rn = RandomNum();
                    //Debug.Log(rn);
                    if (rn > 0.05f)
                    {
                        Transform hex = Instantiate(hexPrefab) as Transform;
                        Vector2 gridPos = new Vector2(x, y);
                        hex.position = CalcWorldPos(gridPos);
                        hex.parent = this.transform;
                        hex.name = "Hexagon" + x + "|" + y;
                        Vector3 hexCentre = new Vector3(hex.position.x, 0, hex.position.z);
                        Transform giz = Instantiate(gizmo, hexCentre, Quaternion.identity);
                        giz.parent = this.transform;
                    }
                    if (rn <= 0.05f)
                    {
                        Transform hex = Instantiate(hexPrefab2) as Transform;
                        Vector2 gridPos = new Vector2(x, y);
                        hex.position = CalcWorldPos(gridPos);
                        hex.parent = this.transform;
                        hex.name = "GreenHexagon" + x + "|" + y;
                        Vector3 hexCentre = new Vector3(hex.position.x, 0, hex.position.z);
                        Transform giz = Instantiate(gizmo, hexCentre, Quaternion.identity);
                        giz.parent = this.transform;
                    }
                }

            }
        }
    }
}