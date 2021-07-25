using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    public RectTransform SelectorImage;
    Rect SelectionRect;
    Vector2 StartPos;
    Vector2 EndPos;

    // Start is called before the first frame update
    void Start()
    {
        DrawRectangle();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartPos = Input.mousePosition;
            SelectionRect = new Rect();
        }

        if(Input.GetMouseButton(0))
        {
            EndPos = Input.mousePosition;
            DrawRectangle();

            if(Input.mousePosition.x < StartPos.x)
            {
                SelectionRect.xMin = Input.mousePosition.x;
                SelectionRect.xMax = StartPos.x;
            }
            else
            {
                SelectionRect.xMin = StartPos.x;
                SelectionRect.xMax = Input.mousePosition.x;
            }

            if (Input.mousePosition.y < StartPos.y)
            {
                SelectionRect.yMin = Input.mousePosition.y;
                SelectionRect.yMax = StartPos.y;
            }
            else
            {
                SelectionRect.yMin = StartPos.y;
                SelectionRect.yMax = Input.mousePosition.y;
            }
        }
    }

    void DrawRectangle()
    {
        Vector2 BoxStart = StartPos;
        Vector2 center = (BoxStart + EndPos)/2;

        SelectorImage.position = center;

        float SizeX = Mathf.Abs(BoxStart.x - EndPos.x);
        float SizeY = Mathf.Abs(BoxStart.y - EndPos.y);

        SelectorImage.sizeDelta = new Vector2(SizeX, SizeY); 

    }

    void CheckSelectedUnits()
    {
        if(SelectionRect.Contains(Camera.main.WorldToScreenPoint(transform.position)))
        {

        }
    }
}
