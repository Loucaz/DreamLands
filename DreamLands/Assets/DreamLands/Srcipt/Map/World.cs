using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    private Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(10, 10, 1f, new Vector3(0, 0));
        Debug.Log("tamer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
