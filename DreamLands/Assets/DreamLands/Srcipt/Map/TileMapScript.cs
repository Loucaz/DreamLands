using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapScript : MonoBehaviour
{
    public Tilemap tilemap;
    public List<TileBase> tiles;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private TileBase GetTile(string name)
    {
        return tiles.Find(x => x.name.Contains(name));
    }

    void OnMouseDown()
    {
        Vector3Int cordinate = Utils.GetMousePosition();
        Debug.Log(" tile : " + tilemap.GetTile(cordinate));
        if (tilemap.GetTile(cordinate).name == "herbe")
        {
            tilemap.SetTile(cordinate, GetTile("chemin"));
            MovePlayer.instance.AnimationPlay("Player_dig");
            Spawn.Item(Inventory.instance.GetRandomItem(), Utils.CastCordinate(cordinate));
        }
        else if (tilemap.GetTile(cordinate).name == "chemin")
        {
            tilemap.SetTile(cordinate, GetTile("herbe"));
            MovePlayer.instance.AnimationPlay("Player_dig");
        }
    }

}
