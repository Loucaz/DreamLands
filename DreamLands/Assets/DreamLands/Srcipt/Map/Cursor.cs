using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        //UnityEngine.Cursor.visible = false;
        Vector3 cordinate = Utils.GetMousePosition();
        cordinate.x += 0.5f;
        cordinate.y += 0.5f;
        transform.position = cordinate;
    }
}
