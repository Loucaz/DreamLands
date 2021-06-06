using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapScript : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase a;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            Vector3Int cordinate = Vector3Int.FloorToInt(Utils.GetMousePosition());
            cordinate.z = 0;
            Debug.Log(" tile : " + tilemap.GetTile(cordinate));
            tilemap.SetTile(cordinate, a);
        }
    }
}
