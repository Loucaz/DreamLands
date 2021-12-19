using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public int MinOrtho = 4;
    public int MaxOrtho = 10;
    public new CinemachineVirtualCamera camera;
    void Update()
    {

        if (Input.GetButtonDown("Zoom"))
        {
            if (Input.GetAxis("Zoom") > 0 && camera.m_Lens.OrthographicSize < MaxOrtho)
            {
                camera.m_Lens.OrthographicSize += 1.5f;
            }
            else if (Input.GetAxis("Zoom") < 0 && camera.m_Lens.OrthographicSize > MinOrtho)
            {
                camera.m_Lens.OrthographicSize -= 1.5f;
            }
        }
    }
}
