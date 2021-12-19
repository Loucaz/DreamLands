using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class Utils 
{

    public static Vector3Int GetMousePosition()
    {
        Vector3Int cordinate = Vector3Int.FloorToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        cordinate.z = 0;

        //Debug.Log(cordinate);
        return cordinate;
    }


    public static Vector3 CastCordinate(Vector3 vecInt)
    {
        Vector3 vec = vecInt;
        vec.x += 0.5f;
        vec.y += 0.5f;
        return vec;
    }
}
