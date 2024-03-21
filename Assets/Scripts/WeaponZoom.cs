using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera fpsCamera;
    
    [SerializeField] float zoomOut = 60f;    
    [SerializeField] float zoomIn = 20f;

    bool zoomedInToggle = false;

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                zoomedInToggle = true;
                fpsCamera.m_Lens.FieldOfView = zoomIn;
            }
            else
            {
                zoomedInToggle = false;
                fpsCamera.m_Lens.FieldOfView = zoomOut;
            }
        }
    }
}
